using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Formats.Asn1;
using System.Globalization;
using System;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using EcoEnergyRazorProject.Data;

namespace EcoEnergyRazorProject.Pages
{
    public class SimulacionsModel : PageModel
    {
        public List<Simulacio> LlistaSimulacions { get; set; } = new List<Simulacio>();
        public bool HasRecords { get; set; } = false;
        public void OnGet()
        {
            using var context = new AplicationDbContext();
            LlistaSimulacions = context.Simulacions.ToList();
            if (LlistaSimulacions.Count() > 0)
            {
                HasRecords = true;
            }
        }
    }
}
