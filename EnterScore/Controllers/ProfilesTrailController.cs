using BusinessLayer.Abstract;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{

    public class ProfilesTrailController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ICloudStorageService _cloudStorageService;

        public ProfilesTrailController(IPlayerService playerService, ICloudStorageService cloudStorageService)
        {
            _playerService = playerService;
            _cloudStorageService = cloudStorageService;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.p = id;
            var value = _playerService.TGetById(id);
            await GenerateSignedUrl(value);
            TempData["id"] = id;
            return View(value);
        }

        public async Task GenerateSignedUrl(Player p)
        {
            if (!string.IsNullOrWhiteSpace(p.SavedFileName))
            {
                p.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(p.SavedFileName);
            }
        }
    }
}
