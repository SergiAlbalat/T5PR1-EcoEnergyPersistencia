using System.ComponentModel.DataAnnotations;

namespace EcoEnergyRazorProject.Models
{
    public class SistemaHidroelectric : SistemaEnergia, ICalculEnergia
    {
        [Required(ErrorMessage = "El cabal d'aigua és obligatori.")]
        [Range(20, 99999999999, ErrorMessage = "El valor minim de cabal d'aigua és de 20 litres per metre cubic")]
        public double CabalAigua { get; set; }

        /// <summary>
        /// Crea una instancia de Sistema Hidroelectric
        /// </summary>
        /// <param name="cabalAigua">Metres cubics d'aigua que pasen per la maquina.</param>
        public SistemaHidroelectric(double cabalAigua)
        {
            if (!ComprovarParametre(cabalAigua))
            {
                throw new ArgumentOutOfRangeException(ErrorForaRang);
            }
            Tipus = "Hidro";
            CabalAigua = cabalAigua;
            Energia = CalcularEnergia();
            Data = DateTime.Now;
        }
        public SistemaHidroelectric() : this(ParametrePerDefecte) { }
        public SistemaHidroelectric(DateTime data, double cabalAigua, double rati, double cost, double preu)
        {
            if (!ComprovarParametre(cabalAigua))
            {
                throw new ArgumentOutOfRangeException(ErrorForaRang);
            }
            Tipus = "Hidro";
            CabalAigua = cabalAigua;
            Data = data;
            Rati = rati;
            Energia = CalcularEnergia();
            Cost = cost;
            Preu = preu;
            CostTotal = CalcularCostTotal();
            PreuTotal = CalcularPreuTotal();
        }
        public bool ComprovarParametre(double argument) => argument >= 20;
        public double CalcularEnergia() => Math.Round(CabalAigua * 9.8 * Rati, 4);
        public void MostrarInformacio()
        {
            Console.WriteLine($"Tipus de Energia\tCabal d'Aigua:\tEnergia Generada:\tData:\n{Tipus}\t{CabalAigua}m3\t{Energia}Kb\t{Data}");
        }
    }
}
