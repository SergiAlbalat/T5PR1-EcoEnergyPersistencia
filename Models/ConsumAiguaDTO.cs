using System.ComponentModel.DataAnnotations;

namespace EcoEnergyRazorProject.Models
{
    public class ConsumAiguaDTO
    {
        public int Any { get; set; }
        public int CodiComarca { get; set; }
        public string? Comarca { get; set; }
        public int Poblacio { get; set; }
        public int DomesticXarxa { get; set; }
        public int ActivitatsFonts { get; set; }
        public int Total { get; set; }
        public double Consum { get; set; }
    }
}
