using EcoEnergyRazorProject.Data;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    }
}
