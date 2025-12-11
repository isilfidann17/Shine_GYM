using System.ComponentModel.DataAnnotations;

namespace SporSalonu_Odev.Models
{
    
    public class GirisModeli
    {
        [Required(ErrorMessage = "E-posta adresini yazılmalı.")]
        [EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz.")]
        [Display(Name = "E-Posta Adresiniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreni girmeyi unuttunuz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Sifre { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool BeniHatirla { get; set; }
    }
}