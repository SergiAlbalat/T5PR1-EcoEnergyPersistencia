using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace EcoEnergyRazorProject.Pages
{
    public class InsertarConsumAiguaModel : PageModel
    {
        [BindProperty]
        public ConsumAigua ConsumAigua { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            XDocument xmlDoc = new XDocument(
                new XElement("ConsumAigua",
                    new XElement("Any", ConsumAigua.Any),
                    new XElement("Comarca",
                        new XElement("Codi", ConsumAigua.CodiComarca),
                        new XElement("Nom", ConsumAigua.Comarca)
                    ),
                    new XElement("Poblacio", ConsumAigua.Poblacio),
                    new XElement("DomesticXarxa", ConsumAigua.DomesticXarxa),
                    new XElement("ActivitatsFonts", ConsumAigua.ActivitatsFonts),
                    new XElement("Total", ConsumAigua.Total),
                    new XElement("Consum", ConsumAigua.Consum)
                )
            );
            xmlDoc.Save(@"wwwroot/Files/consum_aigua_cat_per_comarques.xml");
            return RedirectToPage("ConsumsAigua");
        }
    }
}
