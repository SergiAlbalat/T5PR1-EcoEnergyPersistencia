using System.ComponentModel.DataAnnotations;

namespace EcoEnergyRazorProject.Models
{
    public abstract class SistemaEnergia
    {
        protected string? Tipus { get; set; }
        protected double Energia { get; set; }
        protected DateTime Data { get; set; }
        [Required(ErrorMessage = "El camp es obligatori")]
        [Range(0.000000001, 3, ErrorMessage = "El valor ha d'estar entre 0,00000001 i 3")]
        public double Rati { get; set; }
        [Required(ErrorMessage = "El camp es obligatori")]
        [Range(0, 9999999999999999999, ErrorMessage = "El valor ha de ser positiu")]
        public double Cost { get; set; }
        [Required(ErrorMessage = "El camp es obligatori")]
        [Range(0, 9999999999999999999, ErrorMessage = "El valor ha de ser positiu")]
        public double Preu { get; set; }
        protected double CostTotal {  get; set; }
        protected double PreuTotal {  get; set; }
        protected static int ContadorSimulacions = 0;

        /// <summary>
        /// Dona el constingut del atribut ContadorSimulacions
        /// </summary>
        /// <returns>Contingut de Contador Simulacions</returns>
        public static int GetContador() => ContadorSimulacions;
        protected const double ParametrePerDefecte = 20.0d;
        protected const string ErrorForaRang = "L'argument es troba fora de rang";

        /// <summary>
        /// Dona el contingut del atribut Tipus
        /// </summary>
        /// <returns>Constingut de Tipus</returns>
        public string? GetTipus() => Tipus;

        /// <summary>
        /// Dona el contingut del atribut Energia
        /// </summary>
        /// <returns>Contingut de Energia</returns>
        public double GetEnergia() => Energia;

        /// <summary>
        /// Dona el contingut del atribut Data
        /// </summary>
        /// <returns>Contingut de Data</returns>
        public DateTime GetData() => Data;

        /// <summary>
        /// Dona el contingut del atribut CostTotal
        /// </summary>
        /// <returns>Contingut de CostTotal</returns>
        public double GetCostTotal() => CostTotal;

        /// <summary>
        /// Dona el contingut del atribut PreuTotal
        /// </summary>
        /// <returns>Contingut de PreuTotal</returns>
        public double GetPreuTotal() => PreuTotal;

        /// <summary>
        /// Calcula el cost total per generar la energia
        /// </summary>
        /// <returns>El resultat del calcul</returns>
        protected double CalcularCostTotal() => Cost*Energia;

        /// <summary>
        /// Calcula el preu total al que es vendra la energia generada
        /// </summary>
        /// <returns>El resultat del calcul</returns>
        protected double CalcularPreuTotal() => Preu*Energia;
    }
}
