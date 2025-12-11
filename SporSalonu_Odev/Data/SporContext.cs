using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SporSalonu_Odev.Models;

namespace SporSalonu_Odev.Data
{
   
    public class SporContext : IdentityDbContext
    {
        public SporContext(DbContextOptions<SporContext> options)
            : base(options)
        {
        }

        
        public DbSet<Egitmen> Egitmenler { get; set; }
        public DbSet<SalonHizmeti> Hizmetler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Seans> Seanslar { get; set; }
    }
}