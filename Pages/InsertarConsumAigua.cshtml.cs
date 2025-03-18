using EcoEnergyRazorProject.Data;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyRazorProject.Pages
{
    public class InsertarConsumAiguaModel : PageModel
    {
        [BindProperty]
        public ConsumAigua ConsumAigua { get; set; }
        public IActionResult OnPost()
        {
            using var context = new AplicationDbContext();
            context.ConsumsAigua.Add(ConsumAigua);
            context.SaveChanges();
            return RedirectToPage("ConsumsAigua");
        }
    }
}
