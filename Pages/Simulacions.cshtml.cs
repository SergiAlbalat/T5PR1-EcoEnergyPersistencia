using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Formats.Asn1;
using System.Globalization;
using System;
using System.IO;
using CsvHelper;

namespace EcoEnergyRazorProject.Pages
{
    public class SimulacionsModel : PageModel
    {
        public List<SistemaEnergia> LlistaSimulacions { get; set; } = new List<SistemaEnergia>(300);
        public  bool FileExist { get; set; } = false;
        public void OnGet()
        {
            string arxiu = "../../../wwwroot/Files/simulacions_energia.csv";
            
            if (System.IO.File.Exists(arxiu))
            {
                FileExist = true;
                using var reader = new StreamReader(arxiu);
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var registres = csv.GetRecords<SistemaEnergia>();
                    foreach (var simulacio in registres)
                    {
                        LlistaSimulacions.Add(simulacio);
                    }
                }
            }
        }
    }
}
