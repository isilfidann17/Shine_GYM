using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;

namespace SporSalonu_Odev.Controllers
{
    public class YapayZekaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Olustur(IFormFile resimDosyasi, string hedef, string cinsiyet)
        {
            
            string apiKey = "AIzaSyDGO4ehRL-F3YSP5aBfultz2YI6dGYD53c".Trim();
            
            if (resimDosyasi == null || resimDosyasi.Length == 0)
            {
                ViewBag.Hata = "Lütfen bir fotoğraf yükleyin!";
                return View("Index");
            }

            string tarif = ""; 

            try
            {
                
                

                string base64Image = "";
                using (var ms = new MemoryStream())
                {
                    await resimDosyasi.CopyToAsync(ms);
                    byte[] fileBytes = ms.ToArray();
                    base64Image = Convert.ToBase64String(fileBytes);
                }

                string degisimEmri = hedef == "KiloVer"
                    ? "make the person look very slim, fit and athletic, losing fat"
                    : "make the person look extremely muscular, like a professional bodybuilder with huge muscles";

                var payload = new
                {
                    contents = new[] { new { parts = new object[] {
                        new { text = $"Describe the gender, hair and clothes of the person in this image. THEN described a modified version where they {degisimEmri}. Output ONLY the visual description." },
                        new { inline_data = new { mime_type = "image/jpeg", data = base64Image } }
                    }}}
                };

                string geminiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}";

                using (var client = new HttpClient())
                {
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(geminiUrl, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);
                        tarif = jsonResponse?.candidates?[0]?.content?.parts?[0]?.text;
                    }
                    else
                    {
                        throw new Exception("Google Engellendi"); 
                    }
                }
            }
            catch
            {
                
                
                
                

                string cinsiyetIngilizce = cinsiyet == "Erkek" ? "male" : "female";

                if (hedef == "KiloVer")
                {
                    tarif = $"A realistic fitness photo of a fit {cinsiyetIngilizce} jogging in a gym, athletic body, slim, cinematic lighting, high quality 8k";
                }
                else
                {
                    tarif = $"A realistic bodybuilder photo of a {cinsiyetIngilizce} showing huge muscles, extremely muscular, gym background, cinematic lighting, high quality 8k";
                }
            }

            
            
            string ressamUrl = "https://image.pollinations.ai/prompt/" + System.Net.WebUtility.UrlEncode(tarif) + "?width=1024&height=1024&nologo=true&model=flux";

            ViewBag.ResimUrl = ressamUrl;
            ViewBag.Mesaj = "Dönüşüm Başarıyla Tamamlandı! 💪";

            return View("Index");
        }
    }
}