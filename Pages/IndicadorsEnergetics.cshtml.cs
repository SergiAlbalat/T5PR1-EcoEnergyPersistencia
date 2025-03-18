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
                }
            }
        }
    }
}
