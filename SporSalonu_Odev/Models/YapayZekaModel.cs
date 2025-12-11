using System.ComponentModel.DataAnnotations;

namespace SporSalonu_Odev.Models
{
    public class YapayZekaModel
    {
        [Required(ErrorMessage = "Boyunuzu giriniz (cm).")]
        [Range(100, 250, ErrorMessage = "Lütfen geçerli bir boy giriniz (100-250 cm).")]
        [Display(Name = "Boyunuz (cm)")]
        public int Boy { get; set; }

        [Required(ErrorMessage = "Kilonuzu giriniz (kg).")]
        [Range(30, 300, ErrorMessage = "Lütfen geçerli bir kilo giriniz (30-300 kg).")]
        [Display(Name = "Kilonuz (kg)")]
        public double Kilo { get; set; }

        [Required(ErrorMessage = "Cinsiyet seçimi zorunludur.")]
        [Display(Name = "Cinsiyet")]
        public string Cinsiyet { get; set; } 

        [Required(ErrorMessage = "Hedefinizi seçiniz.")]
        [Display(Name = "Hedefiniz")]
        public string Hedef { get; set; } 

        
        public string? VkiSonuc { get; set; } 
        public string? DurumMesaji { get; set; } 
        public string? OneriProgrami { get; set; } 
        public string? DiyetOnerisi { get; set; } 
    }
}