using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SporSalonu_Odev.Models
{
    public class Seans
    {
        [Key]
        public int SeansId { get; set; }

        [Display(Name = "Gün")]
        public string Gun { get; set; } 

        [Display(Name = "Saat")]
        public string Saat { get; set; } 

        
        public int HizmetId { get; set; }
        [ForeignKey("HizmetId")]
        public virtual SalonHizmeti? Hizmet { get; set; }

        
        public int EgitmenId { get; set; }
        [ForeignKey("EgitmenId")]
        public virtual Egitmen? Egitmen { get; set; }
    }
}