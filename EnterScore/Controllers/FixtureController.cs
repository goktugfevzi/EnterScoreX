using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{

    public class FixtureController : Controller
    {


        private readonly IFixtureService _fixtureService;

        public FixtureController(IFixtureService fixtureService)
        {
            _fixtureService = fixtureService;
        }
        //BU SAYFA BİR İŞE YARAMIYOR TÜM VERİLER SİLİNECEK
        // Ana sayfa - Tüm maçları ve haftaları gösterir
        public IActionResult Index()
        {
            var matches = _fixtureService.TGetMatchesWithTeams();
            return View(matches);
        }

        // Önceki hafta için aksiyon metodu
        public IActionResult PreviousWeek()
        {
            var matches = _fixtureService.TGetMatchesWithTeams();
            var maxWeek = matches.Max(m => m.Week);

            // Mevcut hafta numarasını al
            int currentWeek = int.Parse(HttpContext.Request.Query["currentWeek"]);

            // Şu anki haftadan 1 çıkararak önceki haftaya geç
            int previousWeek = currentWeek - 1;

            // Önceki haftayı kontrol et
            if (previousWeek >= 1)
            {
                // Önceki haftanın maçlarına ulaşmak için query string ekleyerek sayfayı yönlendir
                return RedirectToAction("Index", new { currentWeek = previousWeek });
            }
            else
            {
                // Önceki hafta 1'den küçükse ana sayfaya yönlendir
                return RedirectToAction("Index");
            }
        }

        // Sonraki hafta için aksiyon metodu
        public IActionResult NextWeek()
        {
            var matches = _fixtureService.TGetMatchesWithTeams();
            var maxWeek = matches.Max(m => m.Week);

            // Mevcut hafta numarasını al
            int currentWeek = int.Parse(HttpContext.Request.Query["currentWeek"]);

            // Şu anki haftadan 1 ekleyerek sonraki haftaya geç
            int nextWeek = currentWeek + 1;

            // Sonraki haftayı kontrol et
            if (nextWeek <= maxWeek)
            {
                // Sonraki haftanın maçlarına ulaşmak için query string ekleyerek sayfayı yönlendir
                return RedirectToAction("Index", new { currentWeek = nextWeek });
            }
            else
            {
                // Sonraki hafta mevcut haftadan büyükse, ana sayfaya yönlendir
                return RedirectToAction("Index");
            }
        }
    }
}