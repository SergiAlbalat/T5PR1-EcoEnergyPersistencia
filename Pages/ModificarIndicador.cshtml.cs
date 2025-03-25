using EcoEnergyRazorProject.Data;
using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoEnergyRazorProject.Pages
{
    public class ModificarIndicadorModel : PageModel
    {
        [BindProperty]
        public IndicadorEnergetic IndicadorEnergetic { get; set; }
        public void OnGet()
        {
        }
        public void OnGetIndicador(int id)
        {
            using var context = new AplicationDbContext();
            IndicadorEnergetic = context.IndicadorsEnergetics.Find(id);
        }
        public IActionResult OnPost()
        {
            using var context = new AplicationDbContext();
            IndicadorEnergetic indicadorAModificar = context.IndicadorsEnergetics.Find(IndicadorEnergetic.Id);
            indicadorAModificar.Data = IndicadorEnergetic.Data;
            indicadorAModificar.CDEEBC_ProdNeta = IndicadorEnergetic.CDEEBC_ProdNeta;
            indicadorAModificar.CCAC_GasolinaAuto = IndicadorEnergetic.CCAC_GasolinaAuto;
            indicadorAModificar.CDEEBC_DemandaElectr = IndicadorEnergetic.CDEEBC_DemandaElectr;
            indicadorAModificar.CDEEBC_ProdDisp = IndicadorEnergetic.CDEEBC_ProdDisp;
            context.SaveChanges();
            return RedirectToPage("IndicadorsEnergetics");
        }
    }
}
