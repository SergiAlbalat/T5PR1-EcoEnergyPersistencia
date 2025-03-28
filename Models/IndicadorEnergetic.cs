﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoEnergyRazorProject.Models
{
    public class IndicadorEnergetic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori")]
        public DateTime Data { get; set; }
        public double PBEE_Hidroelectr { get; set; }
        public double PBEE_Carbo { get; set; }
        public double PBEE_GasNat { get; set; }
        public double PBEE_FuelOil { get; set; }
        public double PBEE_CiclComb { get; set; }
        public double PBEE_Nuclear { get; set; }
        public double CDEEBC_ProdBruta { get; set; }
        public double CDEEBC_ConsumAux { get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori")]
        public double CDEEBC_ProdNeta { get; set; }
        public double CDEEBC_ConsumBomb { get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori")]
        public double CDEEBC_ProdDisp { get; set; }
        public double CDEEBC_TotVendesXarxaCentral { get; set; }
        public double CDEEBC_SaldoIntercanviElectr { get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori")]
        public double CDEEBC_DemandaElectr { get; set; }
        public double CDEEBC_TotalEBCMercatRegulat { get; set; }
        public double CDEEBC_TotalEBCMercatLliure { get; set; }
        public double? FEE_Industria { get; set; }
        public double? FEE_Terciari { get; set; }
        public double? FEE_Domestic { get; set; }
        public double? FEE_Primari { get; set; }
        public double? FEE_Energetic { get; set; }
        public double? FEEI_ConsObrPub { get; set; }
        public double? FEEI_SiderFoneria { get; set; }
        public double? FEEI_Metalurgia { get; set; }
        public double? FEEI_IndusVidre { get; set; }
        public double? FEEI_CimentsCalGuix { get; set; }
        public double? FEEI_AltresMatConstr { get; set; }
        public double? FEEI_QuimPetroquim { get; set; }
        public double? FEEI_ConstrMedTrans { get; set; }
        public double? FEEI_RestaTransforMetal { get; set; }
        public double? FEEI_AlimBegudaTabac { get; set; }
        public double? FEEI_TextilConfecCuirCalçat { get; set; }
        public double? FEEI_PastaPaperCartro { get; set; }
        public double? FEEI_AltresIndus { get; set; }
        public double DGGN_PuntFrontEnagas { get; set; }
        public double DGGN_DistrAlimGNL { get; set; }
        public double DGGN_ConsumGNCentrTerm { get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori")]
        public double CCAC_GasolinaAuto { get; set; }
        public double CCAC_GasoilA { get; set; }
    }
}
