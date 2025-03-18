using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace EcoEnergyRazorProject.Models
{
    public class Simulacio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Tipus { get; set; }
        [Required(ErrorMessage = "El camp és obligatori")]
        public double EntradaEnergia { get; set; }
        public double Energia { get; set; }
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "El camp és obligatori")]
        [Range(0.000000001, 3, ErrorMessage = "El valor ha d'estar entre 0,00000001 i 3")]
        public double Rati { get; set; }
        [Required(ErrorMessage = "El camp es obligatori")]
        [Range(0, 9999999999999999999, ErrorMessage = "El valor ha de ser positiu")]
        public double Cost { get; set; }
        [Required(ErrorMessage = "El camp es obligatori")]
        [Range(0, 9999999999999999999, ErrorMessage = "El valor ha de ser positiu")]
        public double Preu { get; set; }
        public double CostTotal {  get; set; }
        public double PreuTotal {  get; set; }
        private const double ParametrePerDefecte = 20.0d;
        private const string ErrorForaRang = "L'argument es troba fora de rang";

        /// <summary>
        /// Constructor de la classe Sistema Energia per llegir csv
        /// </summary>
        /// <param name="data">Data de creacio</param>
        /// <param name="tipus">Tipus Simulacio</param>
        /// <param name="entradaEnergia">Entrada de energia com per exemple hores de sol o velocitat del vent</param>
        /// <param name="rati">Valor pel que es calcula la energia</param>
        /// <param name="cost">Cost per generar la energia</param>
        /// <param name="preu">Preu a la que es ven la energia</param>
        /// <param name="costTotal">Cost total per generar l'energia</param>
        /// <param name="preuTotal">Preu de venta de la totalitat de l'energia</param>
        public Simulacio(string tipus, double entradaEnergia, double energiaGenerada, DateTime data, double rati, double cost, double preu, double costTotal, double preuTotal)
        {
            Tipus = tipus;
            EntradaEnergia = entradaEnergia;
            Data = data;
            Rati = rati;
            Energia = energiaGenerada;
            Cost = cost;
            Preu = preu;
            CostTotal = costTotal;
            PreuTotal = preuTotal;
        }

        /// <summary>
        /// Constructor sense parametres
        /// </summary>
        public Simulacio() : this("Solar", ParametrePerDefecte, 10, DateTime.Now, 2, 0.1, 0.2, 1, 2) { }

        /// <summary>
        /// Constructor de la classe Sistema Energia
        /// </summary>
        /// <param name="data">Data de creacio</param>
        /// <param name="tipus">Tipus Simulacio</param>
        /// <param name="entradaEnergia">Entrada de energia com per exemple hores de sol o velocitat del vent</param>
        /// <param name="rati">Valor pel que es calcula la energia</param>
        /// <param name="cost">Cost per generar la energia</param>
        /// <param name="preu">Preu a la que es ven la energia</param>
        public Simulacio(DateTime data, string tipus, double entradaEnergia, double rati, double cost, double preu)
        {
            double minim = 0;
            Tipus = tipus;
            switch (Tipus)
            {
                case "Solar":
                    minim = 1;
                    break;
                case "Hidro":
                    minim = 19.9;
                    break;
                case "Eolic":
                    minim = 4.9;
                    break;
            }
            if(!(entradaEnergia > minim))
            {
                throw new ArgumentOutOfRangeException(ErrorForaRang);
            }
            EntradaEnergia = entradaEnergia;
            Data = data;
            Rati = rati;
            switch (Tipus)
            {
                case "Solar":
                    Energia = CalcularEnergia(entradaEnergia);
                    break;
                case "Hidro":
                    Energia = CalcularEnergia(entradaEnergia * 9.8);
                    break;
                case "Eolic":
                    Energia = CalcularEnergia(Math.Pow(entradaEnergia, 3));
                    break;
            }
            Cost = cost;
            Preu = preu;
            CostTotal = CalcularCostTotal();
            PreuTotal = CalcularPreuTotal();
        }


        public double CalcularEnergia(double entradaEnergia) => Math.Round(entradaEnergia * Rati, 4);

        /// <summary>
        /// Calcula el cost total per generar la energia
        /// </summary>
        /// <returns>El resultat del calcul</returns>
        private double CalcularCostTotal() => Cost*Energia;

        /// <summary>
        /// Calcula el preu total al que es vendra la energia generada
        /// </summary>
        /// <returns>El resultat del calcul</returns>
        private double CalcularPreuTotal() => Preu*Energia;
    }
}
