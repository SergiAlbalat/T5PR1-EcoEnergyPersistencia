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
    }
}
