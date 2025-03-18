using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoEnergyRazorProject.Models
{
    public class ConsumAigua
    {
        [Required(ErrorMessage = "Aquest camp és obligatori.")]
        public int Any {  get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Aquest camp és obligatori.")]
        public int CodiComarca { get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori.")]
        public string? Comarca { get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori.")]
        public int Poblacio { get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori.")]
        public int DomesticXarxa {  get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori.")]
        public int ActivitatsFonts { get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori.")]
        public int Total {  get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori.")]
        public double Consum {  get; set; }
        
    }
}
