using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EnterScore.Areas.Admin.Method;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RefereeController : Controller
    {
        private readonly IRefereeService _refereeService;
        private readonly ICloudStorageService _cloudStorageService;


        public RefereeController(IRefereeService refereeService, ICloudStorageService cloudStorageService)
        {
            _refereeService = refereeService;
            _cloudStorageService = cloudStorageService;
        }

        public async Task<IActionResult> Index()
        {
            var values = _refereeService.TGetListAll();
            foreach (var value in values)
            {
                await GenerateSignedUrl(value);

            }
            return View(values);
        }
        [HttpGet]
        public IActionResult AddReferee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReferee(Referee p)
        {
            if (ModelState.IsValid)
            {
                if (p.Photo != null)
                {

                    p.SavedFileName = GeneratedFileNameForCloud.GenerateFileNameToSave(p.Photo.FileName);
                    p.SavedUrl = await _cloudStorageService.UploadFileAsync(p.Photo, p.SavedFileName);
                }
                _refereeService.TInsert(p);
            }
            return RedirectToAction("Referee", "Admin");

        }



        public async Task<IActionResult> DeleteReferee(int id)
        {
            var value = _refereeService.TGetById(id);

            if (value != null)
            {
                if (!string.IsNullOrWhiteSpace(value.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(value.SavedFileName);
                    value.SavedFileName = String.Empty;
                    value.SavedUrl = String.Empty;
                }
                _refereeService.TDelete(value);
            }
            return RedirectToAction("Referee", "Admin");

        }


        [HttpGet]
        public async Task<IActionResult> UpdateReferee(int id)
        {
            var value = _refereeService.TGetById(id);
            await GenerateSignedUrl(value);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateReferee(Referee p)
        {
            if (p.Photo != null)
            {
                await ReplacePhoto(p);
            }
            else
            {
                var existingReferee = _refereeService.TGetById(p.RefereeID);
                p.SavedUrl = existingReferee.SavedUrl;
                p.SavedFileName = existingReferee.SavedFileName;
            }
            _refereeService.TUpdate(p);
            return RedirectToAction("Referee", "Admin");
        }



        private async Task ReplacePhoto(Referee referee)
        {
            if (referee.Photo != null)
            {
                if (!string.IsNullOrEmpty(referee.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(referee.SavedFileName);
                }
                referee.SavedFileName = GeneratedFileNameForCloud.GenerateFileNameToSave(referee.Photo.FileName);
                referee.SavedUrl = await _cloudStorageService.UploadFileAsync(referee.Photo, referee.SavedFileName);
            }
        }




        public async Task GenerateSignedUrl(Referee referee)
        {
            // Get Signed URL only when Saved File Name is available.
            if (!string.IsNullOrWhiteSpace(referee.SavedFileName))
            {
                referee.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(referee.SavedFileName);
            }
        }



    }
}
