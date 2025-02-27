using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyRazorProject.Pages
{
    public class AfegirSimulacioModel : PageModel
    {
        [BindProperty]
        public SistemaSolar SistemaSolar { get; set; }
        [BindProperty]
        public SistemaHidroelectric SistemaHidroelectric { get; set; }
        [BindProperty]
        public SistemaEolic SistemaEolic { get; set; }
        [BindProperty]
        public int? Tipus {  get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

            return RedirectToPage("Simulacions");
        }
    }
}
