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
        public SistemaSolar SistemaSolar { get; set; }
        [BindProperty]
        public SistemaHidroelectric SistemaHidroelectric { get; set; }
        [BindProperty]
        public SistemaEolic SistemaEolic { get; set; }
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
            csvWriter.NextRecord();
            switch (Tipus)
            {
                case "1":
                    Console.WriteLine(SistemaEnergia.Preu);
                    SistemaSolar simSolar = new SistemaSolar(DateTime.Now, SistemaSolar.HoresDeSol, SistemaEnergia.Rati, (SistemaEnergia.Cost/100), (SistemaEnergia.Preu/100));
                    Console.WriteLine($"Precio: {simSolar.Preu}");
                    csvWriter.WriteField(simSolar.GetData());
                    csvWriter.WriteField(simSolar.GetTipus());
                    csvWriter.WriteRecord(simSolar);
                    csvWriter.WriteField(simSolar.GetEnergia());
                    csvWriter.WriteField(simSolar.GetCostTotal());
                    csvWriter.WriteField(simSolar.GetPreuTotal());
                    break;
                case "2":
                    SistemaHidroelectric simHidro = new SistemaHidroelectric(DateTime.Now,SistemaHidroelectric.CabalAigua,SistemaEnergia.Rati,(SistemaEnergia.Cost/100),(SistemaEnergia.Preu/100));
                    csvWriter.WriteField(simHidro.GetData());
                    csvWriter.WriteField(simHidro.GetTipus());
                    csvWriter.WriteRecord(simHidro);
                    csvWriter.WriteField(simHidro.GetEnergia());
                    csvWriter.WriteField(simHidro.GetCostTotal());
                    csvWriter.WriteField(simHidro.GetPreuTotal());
                    break;
                case "3":
                    SistemaEolic simEolic = new SistemaEolic(DateTime.Now,SistemaEolic.VelocitatVent,SistemaEnergia.Rati,(SistemaEnergia.Cost/100),(SistemaEnergia.Preu/100));
                    csvWriter.WriteField(simEolic.GetData());
                    csvWriter.WriteField(simEolic.GetTipus());
                    csvWriter.WriteRecord(simEolic);
                    csvWriter.WriteField(simEolic.GetEnergia());
                    csvWriter.WriteField(simEolic.GetCostTotal());
                    csvWriter.WriteField(simEolic.GetPreuTotal());
                    break;
            }
            return RedirectToPage("Simulacions");
        }
    }
}
