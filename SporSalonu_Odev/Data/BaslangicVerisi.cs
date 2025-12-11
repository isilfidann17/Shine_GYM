using Microsoft.AspNetCore.Identity;
using SporSalonu_Odev.Models;

namespace SporSalonu_Odev.Data
{
    
    public static class BaslangicVerisi
    {
        
        public static async Task VerileriDoldur(IServiceProvider serviceProvider)
        {
            
            var rolYonetici = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            var kullaniciYonetici = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            
            
            string[] gerekliRoller = { "Admin", "Uye" };

            foreach (var rolAdi in gerekliRoller)
            {
                
                if (!await rolYonetici.RoleExistsAsync(rolAdi))
                {
                    await rolYonetici.CreateAsync(new IdentityRole(rolAdi));
                }
            }

            
            
            string adminMail = "G221210064@sakarya.edu.tr"; 
            string adminSifre = "sau";

            
            var adminVarMi = await kullaniciYonetici.FindByEmailAsync(adminMail);

            if (adminVarMi == null) 
            {
                var yeniAdmin = new IdentityUser
                {
                    UserName = adminMail,
                    Email = adminMail,
                    EmailConfirmed = true 
                };

                
                var sonuc = await kullaniciYonetici.CreateAsync(yeniAdmin, adminSifre);

                
                if (sonuc.Succeeded)
                {
                    await kullaniciYonetici.AddToRoleAsync(yeniAdmin, "Admin");
                }
            }
        }
    }
}