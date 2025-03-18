using CsvHelper;
using CsvHelper.Configuration;
using EcoEnergyRazorProject.Data;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace EcoEnergyRazorProject.Pages
{
    public class AfegirSimulacioModel : PageModel
    {
        [BindProperty]
        public Simulacio? SistemaEnergia { get; set; }
        [BindProperty]
        public string? Tipus { get; set; }
        public IActionResult OnPost()
        {
            using var context = new AplicationDbContext();
            string tipus = "";
            switch (Tipus)
            {
                case "1":
                    tipus = "Solar";
                    break;
                case "2":
                    tipus = "Hidro";
                    break;
                case "3":
                    tipus = "Eolic";
                    break;
            }
            Simulacio simulacio = new Simulacio(DateTime.Now, tipus, SistemaEnergia.EntradaEnergia, SistemaEnergia.Rati / 10, SistemaEnergia.Cost / 100, SistemaEnergia.Preu / 100);
            context.Simulacions.Add(simulacio);
            context.SaveChanges();
            return RedirectToPage("Simulacions");
        }
    }
}
