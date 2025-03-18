using CsvHelper;
using CsvHelper.Configuration;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace EcoEnergyRazorProject.Pages
{
    public class ConsumsAiguaModel : PageModel
    {
        public List<ConsumAigua> ConsumsAigua { get; set; } = new List<ConsumAigua>();
        public bool FileExist { get; set; } = false;
        public bool HasRecords { get; set; } = false;
        public void OnGet()
        {
            string file = "wwwroot/Files/consum_aigua_cat_per_comarques.csv";
            if (System.IO.File.Exists(file))
            {
                FileExist = true;
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                };
                using (var reader = new StreamReader(file))
                using (var csv = new CsvReader(reader, config))
                {
                    var registres = csv.GetRecords<ConsumAigua>();
                    foreach (var consum in registres)
                    {
                        ConsumsAigua.Add(consum);
                    }
                    if (ConsumsAigua.Count > 0)
                    {
                        HasRecords = true;
                    }
                }
            }
        }
    }
}
