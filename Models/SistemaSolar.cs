using System.ComponentModel.DataAnnotations;

namespace EcoEnergyRazorProject.Models
{
    public class SistemaSolar : SistemaEnergia, ICalculEnergia
    {
        [Required(ErrorMessage = "Les hores de sol son obligatories")]
        [Range(3, 24, ErrorMessage = "El valor minim d'hores es de tres i el maxim de 24")]
        public double HoresDeSol { get; set; }

        /// <summary>
        /// Crea una instancia de Sistema Solar
        /// </summary>
        /// <param name="horesDeSol">Hores durant les que el sol envia llum a la maquina</param>
        public SistemaSolar(double horesDeSol)
        {
            if (!ComprovarParametre(horesDeSol))
            {
                throw new ArgumentOutOfRangeException(ErrorForaRang);
            }
            Tipus = "Solar";
            HoresDeSol = horesDeSol;
            Energia = CalcularEnergia();
            Data = DateTime.Now;
            ContadorSimulacions++;
        }
        public SistemaSolar() : this(ParametrePerDefecte) { }
        public SistemaSolar(DateTime data, double horesDeSol, double rati, double cost, double preu, double costTotal, double preuTotal)
        {
            if (!ComprovarParametre(horesDeSol))
            {
                throw new ArgumentOutOfRangeException(ErrorForaRang);
            }
            Tipus = "Solar";
            HoresDeSol = horesDeSol;
            Data = data;
            ContadorSimulacions++;
            Rati = rati;
            Energia = CalcularEnergia();
            Cost = cost;
            Preu = preu;
            CostTotal = costTotal;
            PreuTotal = preuTotal;
        }
        public bool ComprovarParametre(double argument) => argument > 1;
        public double CalcularEnergia() => Math.Round(HoresDeSol * Rati, 4);
        public void MostrarInformacio()
        {
            Console.WriteLine($"Tipus de Energia\tHores de Sol:\tEnergia Generada:\tData:\n{Tipus}\t{HoresDeSol}\t{Energia}Kb\t{Data}");
        }
    }
}
