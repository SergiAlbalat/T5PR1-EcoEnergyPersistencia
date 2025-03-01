using System.ComponentModel.DataAnnotations;

namespace EcoEnergyRazorProject.Models
{
    public class SistemaEolic : SistemaEnergia, ICalculEnergia
    {
        [Required(ErrorMessage = "La velocitat del vent és obligatoria")]
        [Range(5.00000001, 999999, ErrorMessage = "El valor minim de kn/h és de 5 sense incloir-lo.")]
        public double VelocitatVent { get; set; }

        /// <summary>
        /// Crea una instancia de Sistema Eolic
        /// </summary>
        /// <param name="velocitatVent">Velocitat en m/s del vent que passa per la maquina</param>
        public SistemaEolic(double velocitatVent)
        {
            if (!ComprovarParametre(velocitatVent))
            {
                throw new ArgumentOutOfRangeException(ErrorForaRang);
            }
            Tipus = "Eolic";
            VelocitatVent = velocitatVent;
            Energia = CalcularEnergia();
            Data = DateTime.Now;
        }
        public SistemaEolic() : this(ParametrePerDefecte) { }
        public SistemaEolic(DateTime data, double velocitatVent, double rati, double cost, double preu)
        {
            if (!ComprovarParametre(velocitatVent))
            {
                throw new ArgumentOutOfRangeException(ErrorForaRang);
            }
            Tipus = "Eolic";
            VelocitatVent = velocitatVent;
            Data = data;
            Rati = rati;
            Energia = CalcularEnergia();
            Cost = cost;
            Preu = preu;
            CostTotal = CalcularCostTotal();
            PreuTotal = CalcularPreuTotal();
        }
        public bool ComprovarParametre(double argument) => argument > 5;
        public double CalcularEnergia() => Math.Round(Math.Pow(VelocitatVent, 3) * Rati, 4);
        public void MostrarInformacio()
        {
            Console.WriteLine($"Tipus de Energia\tVelocitat del vent:\tEnergia Generada:\tData:\n{Tipus}\t{VelocitatVent}m/s\t{Energia}Kb\t{Data}");
        }
    }
}
