using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SporSalonu_Odev.Models;

namespace SporSalonu_Odev.Controllers
{
    public class HesapController : Controller
    {
        
        private readonly UserManager<IdentityUser> _kullaniciYoneticisi;
        private readonly SignInManager<IdentityUser> _girisYoneticisi;

        public HesapController(UserManager<IdentityUser> kullaniciYoneticisi, SignInManager<IdentityUser> girisYoneticisi)
        {
            _kullaniciYoneticisi = kullaniciYoneticisi;
            _girisYoneticisi = girisYoneticisi;
        }

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Giris(GirisModeli model)
        {
            if (!ModelState.IsValid) return View(model);

            var sonuc = await _girisYoneticisi.PasswordSignInAsync(model.Email, model.Sifre, model.BeniHatirla, false);

            if (sonuc.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "E-posta veya şifre hatalı.");
            return View(model);
        }

        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kayit(KayitModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var kullanici = new IdentityUser { UserName = model.Email, Email = model.Email };
            var sonuc = await _kullaniciYoneticisi.CreateAsync(kullanici, model.Sifre);

            if (sonuc.Succeeded)
            {
                await _kullaniciYoneticisi.AddToRoleAsync(kullanici, "Uye");

                await _girisYoneticisi.SignInAsync(kullanici, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in sonuc.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        public async Task<IActionResult> Cikis()
        {
            await _girisYoneticisi.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}