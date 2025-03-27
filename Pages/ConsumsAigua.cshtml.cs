using CsvHelper;
using EcoEnergyRazorProject.Data;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace EcoEnergyRazorProject.Pages
{
    public class ConsumsAiguaModel : PageModel
    {
        public List<ConsumAigua> ConsumsAigua { get; set; } = new List<ConsumAigua>();
        public bool HasRecords { get; set; } = false;
        public void OnGet()
        {
            using var context = new AplicationDbContext();
            ConsumsAigua = context.ConsumsAigua.ToList();
            if (ConsumsAigua.Count > 0)
            {
                HasRecords = true;
            }
        }
        public IActionResult OnPostDelete(int id)
        {
            using var context = new AplicationDbContext();
            var consum = context.ConsumsAigua.Find(id);
            if (consum != null)
            {
                context.ConsumsAigua.Remove(consum);
                context.SaveChanges();
            }
            return RedirectToPage("ConsumsAigua");
        }
        public IActionResult OnPostEdit(int id)
        {
            return RedirectToPage("ModificarConsum", "Consum", new { Id = id });
        }

        public IActionResult OnPostSeed()
        {
            using var context = new AplicationDbContext();
            var reader = new StreamReader("wwwroot/Files/consum_aigua_cat_per_comarques.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<ConsumAiguaDTO>().ToList();
            foreach (var r in records) {
                ConsumAigua consum = new ConsumAigua
                {
                    Any = r.Any,
                    CodiComarca = r.CodiComarca,
                    Comarca = r.Comarca,
                    Poblacio = r.Poblacio,
                    DomesticXarxa = r.DomesticXarxa,
                    ActivitatsFonts = r.ActivitatsFonts,
                    Total = r.Total,
                    Consum = r.Consum
                };
                context.ConsumsAigua.Add(consum);
                context.SaveChanges();
            }
            return RedirectToPage("ConsumsAigua");
        }
        public IActionResult OnPostErase()
        {
            using var context = new AplicationDbContext();
            var registres = context.ConsumsAigua.ToList();
            context.ConsumsAigua.RemoveRange(registres);
            context.SaveChanges();
            return RedirectToPage("ConsumsAigua");
        }
    }
}
