namespace EcoEnergyRazorProject.Models
{
    public abstract class SistemaEnergia
    {
        protected string? Tipus { get; set; }
        protected double Energia { get; set; }
        protected DateTime Data { get; set; }
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
    }
}
