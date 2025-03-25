using EcoEnergyRazorProject.Data;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyRazorProject.Pages
{
    public class ModificarConsumModel : PageModel
    {
        [BindProperty]
        public ConsumAigua ConsumAigua { get; set; }
        public void OnGet()
        {
        }
        public void OnGetConsum(int id)
        {
            using var context = new AplicationDbContext();
            ConsumAigua = context.ConsumsAigua.Find(id);
        }
        public IActionResult OnPost()
        {
            using var context = new AplicationDbContext();
            ConsumAigua consumAModificar = context.ConsumsAigua.Find(ConsumAigua.Id);
            consumAModificar.Any = ConsumAigua.Any;
            consumAModificar.CodiComarca = ConsumAigua.CodiComarca;
            consumAModificar.Comarca = ConsumAigua.Comarca;
            consumAModificar.Poblacio = ConsumAigua.Poblacio;
            consumAModificar.DomesticXarxa = ConsumAigua.DomesticXarxa;
            consumAModificar.ActivitatsFonts = ConsumAigua.ActivitatsFonts;
            consumAModificar.Total = ConsumAigua.Total;
            consumAModificar.Consum = ConsumAigua.Consum;
            context.SaveChanges();
            return RedirectToPage("ConsumsAigua");
        }
    }
}
