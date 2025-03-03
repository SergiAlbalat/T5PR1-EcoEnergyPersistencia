using CsvHelper;
using CsvHelper.Configuration;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace EcoEnergyRazorProject.Pages
{
    public class AfegirSimulacioModel : PageModel
    {
        [BindProperty]
        public SistemaEnergia SistemaEnergia { get; set; }
        [BindProperty]
        public string? Tipus {  get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using var stream = System.IO.File.Open("wwwroot/Files/simulacions_energia.csv", FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csvWriter = new CsvWriter(writer, config);
            string tipus = "";
            csvWriter.NextRecord();
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
            SistemaEnergia simulacio = new SistemaEnergia(DateTime.Now, tipus, SistemaEnergia.EntradaEnergia, SistemaEnergia.Rati/10, SistemaEnergia.Cost/100, SistemaEnergia.Preu/100);
            csvWriter.WriteRecord(simulacio);
            return RedirectToPage("Simulacions");
        }
    }
}
