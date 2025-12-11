using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SporSalonu_Odev.Data;
using SporSalonu_Odev.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SporSalonu_Odev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporApiController : ControllerBase
    {
        private readonly SporContext _context;

        public RaporApiController(SporContext context)
        {
            _context = context;
        }

        
        [HttpGet("TumAntrenorler")]
        public async Task<IActionResult> GetAntrenorler()
        {
            var antrenorler = await _context.Egitmenler
                                            .Select(x => new {
                                                x.Id,
                                                x.AdSoyad,
                                                x.Uzmanlik
                                            })
                                            .ToListAsync();

            return Ok(antrenorler);
        }

       
        [HttpGet("Randevular")]
        public async Task<IActionResult> GetRandevular(string? tarih)
        {
            var sorgu = _context.Randevular
                                .Include(r => r.Hizmet)
                                .Include(r => r.Egitmen)
                                .AsQueryable();

            
            if (!string.IsNullOrEmpty(tarih))
            {
                DateTime secilenTarih;
                if (DateTime.TryParse(tarih, out secilenTarih))
                {
                    
                    sorgu = sorgu.Where(r => r.TarihSaat.Date == secilenTarih.Date);
                }
            }

            
            var sonuc = await sorgu.Select(r => new {
                Ogrenci = r.UyeId, 
                Ders = r.Hizmet.HizmetAdi,
                Hoca = r.Egitmen.AdSoyad,
                Tarih = r.TarihSaat
            }).ToListAsync();

            return Ok(sonuc);
        }
    }
}