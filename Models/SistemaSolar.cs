namespace EcoEnergyRazorProject.Models
{
    public class SistemaSolar : SistemaEnergia, ICalculEnergia
    {
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
        public SistemaSolar(double horesDeSol, DateTime data)
        {
            if (!ComprovarParametre(horesDeSol))
            {
                throw new ArgumentOutOfRangeException(ErrorForaRang);
            }
            Tipus = "Solar";
            HoresDeSol = horesDeSol;
            Energia = CalcularEnergia();
            Data = data;
            ContadorSimulacions++;
        }
        public bool ComprovarParametre(double argument) => argument > 1;
        public double CalcularEnergia() => Math.Round(HoresDeSol * 1.5, 4);
        public void MostrarInformacio()
        {
            Console.WriteLine($"Tipus de Energia\tHores de Sol:\tEnergia Generada:\tData:\n{Tipus}\t{HoresDeSol}\t{Energia}Kb\t{Data}");
        }
    }
}
