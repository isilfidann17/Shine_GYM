using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SporSalonu_Odev.Data;
using SporSalonu_Odev.Models;
using Microsoft.AspNetCore.Authorization;

namespace SporSalonu_Odev.Controllers
{
    public class SalonHizmetiController : Controller
    {
        private readonly SporContext _context;

        public SalonHizmetiController(SporContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Program()
        {
            
            var seanslar = await _context.Seanslar
                                         .Include(s => s.Hizmet)
                                         .Include(s => s.Egitmen)
                                         .ToListAsync();
            return View(seanslar);
        }

        
        [Authorize]
        public IActionResult SeansEkle()
        {
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Index", "Home");

            ViewBag.HizmetId = new SelectList(_context.Hizmetler, "HizmetId", "HizmetAdi");
            ViewBag.EgitmenId = new SelectList(_context.Egitmenler, "Id", "AdSoyad");

            
            List<string> gunler = new List<string>() { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
            ViewBag.Gunler = new SelectList(gunler);

           
            List<string> saatler = new List<string>() { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00" };
            ViewBag.Saatler = new SelectList(saatler);

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SeansEkle(Seans seans)
        {
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                _context.Add(seans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Program)); 
            }
            
            ViewBag.HizmetId = new SelectList(_context.Hizmetler, "HizmetId", "HizmetAdi");
            ViewBag.EgitmenId = new SelectList(_context.Egitmenler, "Id", "AdSoyad");
            return View(seans);
        }

        
        [Authorize]
        public async Task<IActionResult> SeansSil(int id)
        {
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Index", "Home");

            var seans = await _context.Seanslar.FindAsync(id);
            if (seans != null)
            {
                _context.Seanslar.Remove(seans);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Program));
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Index", "Home");
            return View(await _context.Hizmetler.ToListAsync());
        }

        [Authorize]
        public IActionResult Create()
        {
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(SalonHizmeti salonHizmeti)
        {
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                _context.Add(salonHizmeti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salonHizmeti);
        }
        
    }
}