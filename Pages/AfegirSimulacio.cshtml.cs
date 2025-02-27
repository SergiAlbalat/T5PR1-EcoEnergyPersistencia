using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyRazorProject.Pages
{
    public class AfegirSimulacioModel : PageModel
    {
        [BindProperty]
        public SistemaEnergia SistemaEnergia { get; set; }
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string arxiu = "../../../wwwroot/Files/simulacions_energia.csv";
            string productLine = $"";
            return RedirectToPage("Simulacions");
        }
    }
}
