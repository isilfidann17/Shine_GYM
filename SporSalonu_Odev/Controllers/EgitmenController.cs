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
    [Authorize] 
    public class EgitmenController : Controller
    {
        private readonly SporContext _context;

        public EgitmenController(SporContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
           
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr")
            {
                return RedirectToAction("Antrenorler", "Home");
            }

            return View(await _context.Egitmenler.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var egitmen = await _context.Egitmenler.FirstOrDefaultAsync(m => m.Id == id);
            if (egitmen == null) return NotFound();
            return View(egitmen);
        }

        
        public IActionResult Create()
        {
           
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Antrenorler", "Home");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdSoyad,Uzmanlik,ResimUrl")] Egitmen egitmen)
        {
            
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Antrenorler", "Home");

            if (ModelState.IsValid)
            {
                _context.Add(egitmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(egitmen);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Antrenorler", "Home");

            if (id == null) return NotFound();
            var egitmen = await _context.Egitmenler.FindAsync(id);
            if (egitmen == null) return NotFound();
            return View(egitmen);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdSoyad,Uzmanlik,ResimUrl")] Egitmen egitmen)
        {
            
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Antrenorler", "Home");

            if (id != egitmen.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egitmen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EgitmenExists(egitmen.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(egitmen);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Antrenorler", "Home");

            if (id == null) return NotFound();
            var egitmen = await _context.Egitmenler.FirstOrDefaultAsync(m => m.Id == id);
            if (egitmen == null) return NotFound();
            return View(egitmen);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            if (User.Identity?.Name != "G221210064@sakarya.edu.tr") return RedirectToAction("Antrenorler", "Home");

            var egitmen = await _context.Egitmenler.FindAsync(id);
            if (egitmen != null) _context.Egitmenler.Remove(egitmen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EgitmenExists(int id)
        {
            return _context.Egitmenler.Any(e => e.Id == id);
        }
    }
}