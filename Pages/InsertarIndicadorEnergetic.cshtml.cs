using EcoEnergyRazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoEnergyRazorProject.Data;

namespace EcoEnergyRazorProject.Pages
{
    public class InsertarIndicadorEnergeticModel : PageModel
    {
        [BindProperty]
        public IndicadorEnergetic IndicadorEnergetic { get; set; }
        public IActionResult OnPost()
        {
            using var context = new AplicationDbContext();
            double valorDefecte = 0;
            IndicadorEnergetic indicador = new IndicadorEnergetic{
                Data = IndicadorEnergetic.Data,
                PBEE_Hidroelectr = valorDefecte,
                PBEE_Carbo = valorDefecte,
                PBEE_GasNat = valorDefecte,
                PBEE_FuelOil = valorDefecte,
                PBEE_CiclComb = valorDefecte,
                PBEE_Nuclear = valorDefecte,
                CDEEBC_ProdBruta = valorDefecte,
                CDEEBC_ConsumAux = valorDefecte,
                CDEEBC_ProdNeta = IndicadorEnergetic.CDEEBC_ProdNeta,
                CDEEBC_ConsumBomb = valorDefecte,
                CDEEBC_ProdDisp = IndicadorEnergetic.CDEEBC_ProdDisp,
                CDEEBC_TotVendesXarxaCentral = valorDefecte,
                CDEEBC_SaldoIntercanviElectr = valorDefecte,
                CDEEBC_DemandaElectr = IndicadorEnergetic.CDEEBC_DemandaElectr,
                CDEEBC_TotalEBCMercatRegulat = valorDefecte,
                CDEEBC_TotalEBCMercatLliure = valorDefecte,
                FEE_Industria = valorDefecte,
                FEE_Terciari = valorDefecte,
                FEE_Domestic = valorDefecte,
                FEE_Primari = valorDefecte,
                FEE_Energetic = valorDefecte,
                FEEI_ConsObrPub = valorDefecte,
                FEEI_SiderFoneria = valorDefecte,
                FEEI_Metalurgia = valorDefecte,
                FEEI_IndusVidre = valorDefecte,
                FEEI_CimentsCalGuix = valorDefecte,
                FEEI_AltresMatConstr = valorDefecte,
                FEEI_QuimPetroquim = valorDefecte,
                FEEI_ConstrMedTrans = valorDefecte,
                FEEI_RestaTransforMetal = valorDefecte,
                FEEI_AlimBegudaTabac = valorDefecte,
                FEEI_TextilConfecCuirCalçat = valorDefecte,
                FEEI_PastaPaperCartro = valorDefecte,
                FEEI_AltresIndus = valorDefecte,
                DGGN_PuntFrontEnagas = valorDefecte,
                DGGN_DistrAlimGNL = valorDefecte,
                DGGN_ConsumGNCentrTerm = valorDefecte,
                CCAC_GasolinaAuto = IndicadorEnergetic.CCAC_GasolinaAuto,
                CCAC_GasoilA = valorDefecte
            };
            context.IndicadorsEnergetics.Add(indicador);
            context.SaveChanges();
            return RedirectToPage("IndicadorsEnergetics");
        }
    }
}
