using System.ComponentModel.DataAnnotations;

namespace SporSalonu_Odev.Models
{
    public class SalonHizmeti
    {
        [Key]
        public int HizmetId { get; set; }

        [Display(Name = "Hizmet Adı")]
        [Required(ErrorMessage = "Hizmet adı zorunludur")]
        public string HizmetAdi { get; set; }

        [Display(Name = "Süre (Dakika)")]
        public int SureDakika { get; set; } 

        [Display(Name = "Ücret (TL)")]
        public decimal Ucret { get; set; }
    }
}