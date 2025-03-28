﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoEnergyRazorProject.Migrations
{
    /// <inheritdoc />
    public partial class ConsumAiguaIdChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumsAigua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Any = table.Column<int>(type: "int", nullable: false),
                    CodiComarca = table.Column<int>(type: "int", nullable: false),
                    Comarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poblacio = table.Column<int>(type: "int", nullable: false),
                    DomesticXarxa = table.Column<int>(type: "int", nullable: false),
                    ActivitatsFonts = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Consum = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumsAigua", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorsEnergetics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PBEE_Hidroelectr = table.Column<double>(type: "float", nullable: false),
                    PBEE_Carbo = table.Column<double>(type: "float", nullable: false),
                    PBEE_GasNat = table.Column<double>(type: "float", nullable: false),
                    PBEE_FuelOil = table.Column<double>(type: "float", nullable: false),
                    PBEE_CiclComb = table.Column<double>(type: "float", nullable: false),
                    PBEE_Nuclear = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_ProdBruta = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_ConsumAux = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_ProdNeta = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_ConsumBomb = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_ProdDisp = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_TotVendesXarxaCentral = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_SaldoIntercanviElectr = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_DemandaElectr = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_TotalEBCMercatRegulat = table.Column<double>(type: "float", nullable: false),
                    CDEEBC_TotalEBCMercatLliure = table.Column<double>(type: "float", nullable: false),
                    FEE_Industria = table.Column<double>(type: "float", nullable: true),
                    FEE_Terciari = table.Column<double>(type: "float", nullable: true),
                    FEE_Domestic = table.Column<double>(type: "float", nullable: true),
                    FEE_Primari = table.Column<double>(type: "float", nullable: true),
                    FEE_Energetic = table.Column<double>(type: "float", nullable: true),
                    FEEI_ConsObrPub = table.Column<double>(type: "float", nullable: true),
                    FEEI_SiderFoneria = table.Column<double>(type: "float", nullable: true),
                    FEEI_Metalurgia = table.Column<double>(type: "float", nullable: true),
                    FEEI_IndusVidre = table.Column<double>(type: "float", nullable: true),
                    FEEI_CimentsCalGuix = table.Column<double>(type: "float", nullable: true),
                    FEEI_AltresMatConstr = table.Column<double>(type: "float", nullable: true),
                    FEEI_QuimPetroquim = table.Column<double>(type: "float", nullable: true),
                    FEEI_ConstrMedTrans = table.Column<double>(type: "float", nullable: true),
                    FEEI_RestaTransforMetal = table.Column<double>(type: "float", nullable: true),
                    FEEI_AlimBegudaTabac = table.Column<double>(type: "float", nullable: true),
                    FEEI_TextilConfecCuirCalçat = table.Column<double>(type: "float", nullable: true),
                    FEEI_PastaPaperCartro = table.Column<double>(type: "float", nullable: true),
                    FEEI_AltresIndus = table.Column<double>(type: "float", nullable: true),
                    DGGN_PuntFrontEnagas = table.Column<double>(type: "float", nullable: false),
                    DGGN_DistrAlimGNL = table.Column<double>(type: "float", nullable: false),
                    DGGN_ConsumGNCentrTerm = table.Column<double>(type: "float", nullable: false),
                    CCAC_GasolinaAuto = table.Column<double>(type: "float", nullable: false),
                    CCAC_GasoilA = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorsEnergetics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simulacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntradaEnergia = table.Column<double>(type: "float", nullable: false),
                    Energia = table.Column<double>(type: "float", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rati = table.Column<double>(type: "float", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Preu = table.Column<double>(type: "float", nullable: false),
                    CostTotal = table.Column<double>(type: "float", nullable: false),
                    PreuTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulacions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumsAigua");

            migrationBuilder.DropTable(
                name: "IndicadorsEnergetics");

            migrationBuilder.DropTable(
                name: "Simulacions");
        }
    }
}
