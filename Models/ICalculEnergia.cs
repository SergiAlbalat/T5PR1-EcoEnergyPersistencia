namespace EcoEnergyRazorProject.Models
{
    public interface ICalculEnergia
    {
        /// <summary>
        /// Calcula si un parametre esta dins del rang acceptat per un objecte
        /// </summary>
        /// <param name="argument">Argument enviat per l'usuari a traves d'un constructor per calcular l'energia</param>
        /// <returns>Si el valor es correcte o no</returns>
        bool ComprovarParametre(double argument);

        /// <summary>
        /// Calcula la energia del objecte a traves de la formula corresponent
        /// </summary>
        /// <returns>Energia resultant de la formula.</returns>
        double CalcularEnergia();

        /// <summary>
        /// Imprimeix per pantalla la informació del objecte
        /// </summary>
        void MostrarInformacio();
    }
}
