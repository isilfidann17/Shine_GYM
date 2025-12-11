using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SporSalonu_Odev.Models
{
    public class Randevu
    {
        [Key]
        public int Id { get; set; }

        
        
        [Display(Name = "Üye ID")]
        public string? UyeId { get; set; }

        
        [Display(Name = "Eğitmen")]
        public int EgitmenId { get; set; }

        [ForeignKey("EgitmenId")]
        public virtual Egitmen? Egitmen { get; set; } 

        
        [Display(Name = "Hizmet")]
        public int HizmetId { get; set; }

        [ForeignKey("HizmetId")]
        public virtual SalonHizmeti? Hizmet { get; set; } 

        
        [Display(Name = "Randevu Tarihi")]
        [Required(ErrorMessage = "Tarih ve Saat seçmelisiniz")]
        public DateTime TarihSaat { get; set; }

        
        
        [Display(Name = "Onay Durumu")]
        public bool OnaylandiMi { get; set; } = true; 
    }
}