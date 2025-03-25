using EcoEnergyRazorProject.Data;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyRazorProject.Pages
{
    public class ModificarSimulacioModel : PageModel
    {
        [BindProperty]
        public Simulacio Simulacio { get; set; }
        public void OnGet()
        {

        }
        public void OnGetSimulacio(int id)
        {
            using var context = new AplicationDbContext();
            Simulacio = context.Simulacions.Find(id);
        }
        public IActionResult OnPost()
        {
            using var context = new AplicationDbContext();
            Simulacio simulacioAModificar = context.Simulacions.Find(Simulacio.Id);
            Simulacio simulacioModificada = new Simulacio(Simulacio.Data, Simulacio.Tipus, Simulacio.EntradaEnergia, Simulacio.Rati/10, Simulacio.Cost/100, Simulacio.Preu/100);
            simulacioAModificar.Tipus = simulacioModificada.Tipus;
            simulacioAModificar.EntradaEnergia = simulacioModificada.EntradaEnergia;
            simulacioAModificar.Rati = simulacioModificada.Rati;
            simulacioAModificar.Energia = simulacioModificada.Energia;
            simulacioAModificar.Cost = simulacioModificada.Cost;
            simulacioAModificar.Preu = simulacioModificada.Preu;
            simulacioAModificar.CostTotal = simulacioModificada.CostTotal;
            simulacioAModificar.PreuTotal = simulacioModificada.PreuTotal;
            context.SaveChanges();
            return RedirectToPage("Simulacions");
        }
    }
}
