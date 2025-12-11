using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SporSalonu_Odev.Data;
using SporSalonu_Odev.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SporSalonu_Odev.Controllers
{
    [Authorize]
    public class RandevuController : Controller
    {
        private readonly SporContext _context;

        public RandevuController(SporContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var uyeId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var randevularim = await _context.Randevular
                .Include(r => r.Hizmet)   
                .Include(r => r.Egitmen)  
                .Where(r => r.UyeId == uyeId) 
                .OrderBy(r => r.TarihSaat)    
                .ToListAsync();

            return View(randevularim);
        }
        public IActionResult Create(string? dersAdi, string? gun, string? saat)
        {
            var randevuModeli = new Randevu();

            if (!string.IsNullOrEmpty(gun) && !string.IsNullOrEmpty(saat))
            {
                DateTime hedefTarih = DateTime.Now;
                DayOfWeek hedefGun = DayOfWeek.Monday; 

                string gelenGun = gun.ToUpper(new System.Globalization.CultureInfo("tr-TR")).Trim();

                if (gelenGun == "SALI") hedefGun = DayOfWeek.Tuesday;
                else if (gelenGun == "ÇARŞAMBA" || gelenGun == "CARSAMBA") hedefGun = DayOfWeek.Wednesday;
                else if (gelenGun == "PERŞEMBE" || gelenGun == "PERSEMBE") hedefGun = DayOfWeek.Thursday;
                else if (gelenGun == "CUMA") hedefGun = DayOfWeek.Friday;
                else if (gelenGun == "CUMARTESİ" || gelenGun == "CUMARTESI") hedefGun = DayOfWeek.Saturday;
                else if (gelenGun == "PAZAR") hedefGun = DayOfWeek.Sunday;

                while (hedefTarih.DayOfWeek != hedefGun)
                {
                    hedefTarih = hedefTarih.AddDays(1);
                }

                var saatParcalari = saat.Split(':');
                int saatInt = int.Parse(saatParcalari[0]);
                int dakikaInt = int.Parse(saatParcalari[1]);

                randevuModeli.TarihSaat = new DateTime(hedefTarih.Year, hedefTarih.Month, hedefTarih.Day, saatInt, dakikaInt, 0);
            }

            ViewBag.EgitmenId = new SelectList(_context.Egitmenler, "Id", "AdSoyad");

            var hizmetListesi = _context.Hizmetler.Select(h => new
            {
                HizmetId = h.HizmetId,
                AdVeUcret = h.HizmetAdi + " (" + h.Ucret + " TL)",
                IsSelected = (dersAdi != null && h.HizmetAdi.Contains(dersAdi))
            }).ToList();

            var seciliHizmet = hizmetListesi.FirstOrDefault(x => x.IsSelected)?.HizmetId;
            ViewBag.HizmetId = new SelectList(hizmetListesi, "HizmetId", "AdVeUcret", seciliHizmet);

            return View(randevuModeli);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Randevu randevu)
        {
            var uyeId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            randevu.UyeId = uyeId;

            bool randevuZatenVar = await _context.Randevular.AnyAsync(x =>
                x.UyeId == uyeId &&
                x.TarihSaat == randevu.TarihSaat);

            if (randevuZatenVar)
            {
                ModelState.AddModelError("TarihSaat", "⚠️ Bu seans için zaten kaydınız var! Aynı dersi tekrar alamazsınız.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return View("Onay");
            }

            ViewBag.EgitmenId = new SelectList(_context.Egitmenler, "Id", "AdSoyad");
            var hizmetListesi = _context.Hizmetler.Select(h => new
            {
                HizmetId = h.HizmetId,
                AdVeUcret = h.HizmetAdi + " (" + h.Ucret + " TL)"
            }).ToList();
            ViewBag.HizmetId = new SelectList(hizmetListesi, "HizmetId", "AdVeUcret");

            return View(randevu);
        }
    
[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Iptal(int id)
        {
            var uyeId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var randevu = await _context.Randevular.FindAsync(id);

            
            if (randevu != null && randevu.UyeId == uyeId)
            {
                _context.Randevular.Remove(randevu);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}