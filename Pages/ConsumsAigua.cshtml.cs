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
        public List<ConsumAigua> MajorsConsums { get; set; } = new List<ConsumAigua>();
        public List<MitjanaConsumAigua> MitjanesConsums { get; set; } = new List<MitjanaConsumAigua>();
        public List<ConsumAigua> ConsumsSospitosos { get; set; } = new List<ConsumAigua>();
        public List<Comarca> LlocsAugment { get; set; } = new List<Comarca>();
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
                using (var reader = new StreamReader("wwwroot/Files/consum_aigua_cat_per_comarques.csv"))
                using (var csv = new CsvReader(reader, config))
                {
                    var registres = csv.GetRecords<ConsumAigua>();
                    foreach (var consum in registres)
                    {
                        ConsumsAigua.Add(consum);
                    }
                    if (ConsumsAigua.Count() > 0)
                    {
                        HasRecords = true;
                    }
                    MajorsConsums = ConsumsAigua.OrderByDescending(consum => consum.Total).Where(consum => consum.Any == ConsumsAigua.Max(consum => consum.Any)).Take(10).ToList();
                    MitjanesConsums = ConsumsAigua.GroupBy(v => v.Comarca).Select(g => new MitjanaConsumAigua
                        {
                            Comarca = g.Key,          
                            Mitjana = g.Average(v => v.Consum)
                        }).OrderByDescending(consum => consum.Mitjana).ToList();
                    ConsumsSospitosos = ConsumsAigua.Where(n => n.Total > 999999).ToList();
                    int maxAny = ConsumsAigua.Max(n => n.Any);
                    int anyMinim = maxAny - 5;
                    LlocsAugment = ConsumsAigua.Where(n => n.Any >= anyMinim).GroupBy(n => n.Comarca).Where(g => g.FirstOrDefault(r => r.Any == anyMinim) != null && g.FirstOrDefault(r => r.Any == maxAny) != null).Where(g => g.First(r => r.Any == maxAny).Total > g.First(r => r.Any == anyMinim).Total).Select( g => new Comarca { Nom = g.Key }).ToList();
                }
            }
            
        }
    }
}
