using CsvHelper.Configuration;
using CsvHelper;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace EcoEnergyRazorProject.Pages
{
    public class IndicadorsEnergeticsModel : PageModel
    {
        public bool FileExist { get; set; } = false;
        public bool HasRecords { get; set; } = false;
        public List<IndicadorEnergetic> IndicadorsEnergetics { get; set; } = new List<IndicadorEnergetic>();
        public List<IndicadorEnergetic> ProdNetaSuperior { get; set; } = new List<IndicadorEnergetic>();
        public List<IndicadorEnergetic> ConsumGasolinaSuperior { get; set; } = new List<IndicadorEnergetic>();
        public List<MitjanaIndicadorEnergetic> MitjanesIndicadors { get; set; } = new List<MitjanaIndicadorEnergetic>();
        public List<IndicadorEnergetic> AltaDemandaBaixaProduccio { get; set; } = new List<IndicadorEnergetic>();
        public void OnGet()
        {
            string file = "wwwroot/Files/indicadors_energetics_cat.csv";
            if (System.IO.File.Exists(file))
            {
                FileExist = true;
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                };
                using (var reader = new StreamReader(file))
                using (var csv = new CsvReader(reader, config))
                {
                    var registres = csv.GetRecords<IndicadorEnergetic>();
                    foreach (var indicador in registres)
                    {
                        IndicadorsEnergetics.Add(indicador);
                    }
                    if (IndicadorsEnergetics.Count > 0)
                    {
                        HasRecords = true;
                    }
                    ProdNetaSuperior = IndicadorsEnergetics.Where(indicador => indicador.CDEEBC_ProdNeta > 3000).OrderBy(indicador => indicador.CDEEBC_ProdNeta).ToList();
                    ConsumGasolinaSuperior = IndicadorsEnergetics.Where(indicador => indicador.CCAC_GasolinaAuto > 100).OrderByDescending(indicador => indicador.CCAC_GasolinaAuto).ToList();
                    MitjanesIndicadors = IndicadorsEnergetics.GroupBy(v => v.Data.Year).Select(g => new MitjanaIndicadorEnergetic
                    {
                        Any = g.Key,
                        ProduccioNetaMitjana = g.Average(v => v.CDEEBC_ProdNeta)
                    }).OrderBy(indicador => indicador.ProduccioNetaMitjana).ToList();
                    AltaDemandaBaixaProduccio = IndicadorsEnergetics.Where(indicador => indicador.CDEEBC_DemandaElectr > 4000 && indicador.CDEEBC_ProdDisp < 300).ToList();
                }
            }
        }
    }
}
