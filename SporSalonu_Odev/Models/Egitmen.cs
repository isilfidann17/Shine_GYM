using System.ComponentModel.DataAnnotations;

namespace SporSalonu_Odev.Models
{
    public class Egitmen
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Adı Soyadı")]
        [Required(ErrorMessage = "Lütfen eğitmen adını giriniz.")]
        public string AdSoyad { get; set; }

        [Display(Name = "Uzmanlık Alanı")]
        [Required(ErrorMessage = "Örn: Pilates, Fitness, Yoga")]
        public string Uzmanlik { get; set; }

        [Display(Name = "Hizmet Türleri")]
        [Required(ErrorMessage = "Örn: Kilo Verme, Kas Kazanımı, Esneklik")]
        public string HizmetTurleri { get; set; }

        [Display(Name = "Müsaitlik Saatleri")]
        [Required(ErrorMessage = "Örn: 09:00 - 17:00")]
        public string Musaitlik { get; set; }

        [Display(Name = "Fotoğraf Linki")]
        public string FotoUrl { get; set; } 

        [Display(Name = "Biyografi / Slogan")]
        public string Aciklama { get; set; }
    }
}