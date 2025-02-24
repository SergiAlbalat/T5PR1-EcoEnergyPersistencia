namespace EcoEnergyRazorProject.Models
{
    public class SistemaEolic : SistemaEnergia, ICalculEnergia
    {
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
            ContadorSimulacions++;
        }
        public SistemaEolic() : this(ParametrePerDefecte) { }
        public bool ComprovarParametre(double argument) => argument > 5;
        public double CalcularEnergia() => Math.Round(Math.Pow(VelocitatVent, 3) * 0.2, 4);
        public void MostrarInformacio()
        {
            Console.WriteLine($"Tipus de Energia\tVelocitat del vent:\tEnergia Generada:\tData:\n{Tipus}\t{VelocitatVent}m/s\t{Energia}Kb\t{Data}");
        }
    }
}
