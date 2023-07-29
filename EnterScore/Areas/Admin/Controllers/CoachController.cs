using BusinessLayer.Abstract;
using EnterScore.Areas.Admin.Method;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoachController : Controller
    {
        private readonly ICoachService _coachService;
        private readonly ICloudStorageService _cloudStorageService;


        public CoachController(ICoachService coachService, ICloudStorageService cloudStorageService)
        {
            _coachService = coachService;
            _cloudStorageService = cloudStorageService;
        }
        public async Task<IActionResult> Index()
        {
            var values = _coachService.TGetListAll();
            foreach (var value in values)
            {
                await GenerateSignedUrl(value);

            }
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCoach()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCoach(Coach p)
        {
            if (ModelState.IsValid)
            {
                if (p.Photo != null)
                {
                    p.SavedFileName = GeneratedFileNameForCloud.GenerateFileNameToSave(p.Photo.FileName);
                    p.SavedUrl = await _cloudStorageService.UploadFileAsync(p.Photo, p.SavedFileName);
                }
                _coachService.TInsert(p);
            }
            return RedirectToAction("Coach", "Admin");

        }

        public async Task<IActionResult> DeleteCoach(int id)
        {
            var value = _coachService.TGetById(id);
            if (value != null)
            {
                if (!string.IsNullOrWhiteSpace(value.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(value.SavedFileName);
                    value.SavedFileName = String.Empty;
                    value.SavedUrl = String.Empty;
                }
                _coachService.TDelete(value);
            }
            return RedirectToAction("Coach", "Admin");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateCoach(int id)
        {
            var value = _coachService.TGetById(id);
            await GenerateSignedUrl(value);

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCoach(Coach p)
        {
            if (p.Photo != null)
            {
                await ReplacePhoto(p);
            }
            else
            {
                var existingCoach = _coachService.TGetById(p.CoachID);
                p.SavedUrl = existingCoach.SavedUrl;
                p.SavedFileName = existingCoach.SavedFileName;
            }
            _coachService.TUpdate(p);
            return RedirectToAction("Coach", "Admin");

        }

        private async Task ReplacePhoto(Coach p)
        {
            if (p.Photo != null)
            {
                if (!string.IsNullOrEmpty(p.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(p.SavedFileName);
                }
                p.SavedFileName = GeneratedFileNameForCloud.GenerateFileNameToSave(p.Photo.FileName);
                p.SavedUrl = await _cloudStorageService.UploadFileAsync(p.Photo, p.SavedFileName);
            }
        }
        public async Task GenerateSignedUrl(Coach p)
        {
            if (!string.IsNullOrWhiteSpace(p.SavedFileName))
            {
                p.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(p.SavedFileName);
            }
        }
    }
}




