using CsvHelper;
using CsvHelper.Configuration;
using EcoEnergyRazorProject.Data;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace EcoEnergyRazorProject.Pages
{
    public class ConsumsAiguaModel : PageModel
    {
        public List<ConsumAigua> ConsumsAigua { get; set; } = new List<ConsumAigua>();
        public bool HasRecords { get; set; } = false;
        public void OnGet()
        {
            using var context = new AplicationDbContext();
            ConsumsAigua = context.ConsumsAigua.ToList();
            if (ConsumsAigua.Count > 0)
            {
                HasRecords = true;
            }
        }
    }
}
