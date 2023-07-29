using BusinessLayer.Abstract;
using EnterScore.Areas.Admin.Method;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StadiumController : Controller
    {
        private readonly IStadiumService _stadiumService;
        private readonly ICloudStorageService _cloudStorageService;


        public StadiumController(IStadiumService stadiumService, ICloudStorageService cloudStorageService)
        {
            _stadiumService = stadiumService;
            _cloudStorageService = cloudStorageService;
        }


        public async Task<IActionResult> Index()
        {
            var values = _stadiumService.TGetListAll();
            foreach (var value in values)
            {
                await GenerateSignedUrl(value);
            }
            return View(values);
        }


        [HttpGet]
        public IActionResult AddStadium()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStadium(Stadium p)
        {
            if (ModelState.IsValid)
            {
                if (p.Photo != null)
                {
                    p.SavedFileName = GeneratedFileNameForCloud.GenerateFileNameToSave(p.Photo.FileName);
                    p.SavedUrl = await _cloudStorageService.UploadFileAsync(p.Photo, p.SavedFileName);
                }
            }
            _stadiumService.TInsert(p);
            return RedirectToAction("Stadium", "Admin");
        }


        public async Task<IActionResult> DeleteStadium(int id)
        {
            var value = _stadiumService.TGetById(id);
            if (value != null)
            {
                if (!string.IsNullOrWhiteSpace(value.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(value.SavedFileName);
                    value.SavedFileName = String.Empty;
                    value.SavedUrl = String.Empty;
                }
                _stadiumService.TDelete(value);
            }
            return RedirectToAction("Stadium", "Admin");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateStadium(int id)
        {
            var value = _stadiumService.TGetById(id);
            await GenerateSignedUrl(value);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStadium(Stadium p)
        {
            if (p.Photo != null)
            {
                await ReplacePhoto(p);
            }
            else
            {
                var existingTeam = _stadiumService.TGetById(p.StadiumID);
                p.SavedUrl = existingTeam.SavedUrl;
                p.SavedFileName = existingTeam.SavedFileName;
            }
            _stadiumService.TUpdate(p);

            return RedirectToAction("Stadium", "Admin");

        }
        private async Task ReplacePhoto(Stadium p)
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
        public async Task GenerateSignedUrl(Stadium p)
        {
            if (!string.IsNullOrWhiteSpace(p.SavedFileName))
            {
                p.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(p.SavedFileName);
            }
        }
    }
}



