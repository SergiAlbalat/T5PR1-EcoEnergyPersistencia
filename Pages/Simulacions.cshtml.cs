using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Formats.Asn1;
using System.Globalization;
using System;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace EcoEnergyRazorProject.Pages
{
    public class SimulacionsModel : PageModel
    {
        public List<Simulacio> LlistaSimulacions { get; set; } = new List<Simulacio>();
        public  bool FileExist { get; set; } = false;
        public bool HasRecords { get; set; } = false;
        public void OnGet()
        {
            string arxiu = "wwwroot/Files/simulacions_energia.csv";
            
            if (System.IO.File.Exists(arxiu))
            {
                FileExist = true;
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                };
                using var reader = new StreamReader(arxiu);
                using (var csv = new CsvReader(reader, config))
                {
                    var registres = csv.GetRecords<Simulacio>();
                    foreach (var simulacio in registres)
                    {
                        LlistaSimulacions.Add(simulacio);
                    }
                    if(LlistaSimulacions.Count() > 0)
                    {
                        HasRecords = true;
                    }
                }
            }
        }
    }
}
