using CsvHelper.Configuration;
using CsvHelper;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using EcoEnergyRazorProject.Data;

namespace EcoEnergyRazorProject.Pages
{
    public class IndicadorsEnergeticsModel : PageModel
    {
        public bool HasRecords { get; set; } = false;
        public List<IndicadorEnergetic> IndicadorsEnergetics { get; set; } = new List<IndicadorEnergetic>();
        public void OnGet()
        {
            using var context = new AplicationDbContext();
            IndicadorsEnergetics = context.IndicadorsEnergetics.ToList();
            if (IndicadorsEnergetics.Count > 0)
            {
                HasRecords = true;
            }
        }
        public IActionResult OnPostDelete(int id)
        {
            using var context = new AplicationDbContext();
            var indicador = context.IndicadorsEnergetics.Find(id);
            if (indicador != null)
            {
                context.IndicadorsEnergetics.Remove(indicador);
                context.SaveChanges();
            }
            return RedirectToPage("IndicadorsEnergetics");
        }
        public IActionResult OnPostEdit(int id)
        {
            return RedirectToPage("ModificarIndicador", "Indicador", new { Id = id });
        }
        public IActionResult OnPostSeed()
        {
            using var context = new AplicationDbContext();
            var reader = new StreamReader("wwwroot/Files/indicadors_energetics_cat.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<IndicadorEnergeticDTO>().ToList();
            foreach (var r in records)
            {
                IndicadorEnergetic indicador = new IndicadorEnergetic
                {
                    Data = r.Data,
                    CDEEBC_ProdNeta = r.CDEEBC_ProdNeta,
                    CCAC_GasolinaAuto = r.CCAC_GasolinaAuto,
                    CDEEBC_DemandaElectr = r.CDEEBC_DemandaElectr,
                    CDEEBC_ProdDisp = r.CDEEBC_ProdDisp
                };
                context.IndicadorsEnergetics.Add(indicador);
                context.SaveChanges();
            }
            return RedirectToPage("IndicadorsEnergetics");
        }
        public IActionResult OnPostErase()
        {
            using var context = new AplicationDbContext();
            var registres = context.IndicadorsEnergetics.ToList();
            context.IndicadorsEnergetics.RemoveRange(registres);
            context.SaveChanges(); 
            return RedirectToPage("IndicadorsEnergetics");
        }
    }
}
