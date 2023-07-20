using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StadiumController : Controller
    {
        private readonly IStadiumService _stadiumService;

        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        public IActionResult Index()
        {
            var values = _stadiumService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddStadium()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStadium(Stadium p, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin_panel", "img", fileName);
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                p.ImageURL = "/admin_panel/img/" + fileName;
            }

            _stadiumService.TInsert(p);
            return RedirectToAction("Stadium", "Admin");

        }

        public IActionResult DeleteStadium(int id)
        {
            var value = _stadiumService.TGetById(id);
            _stadiumService.TDelete(value);
            return RedirectToAction("Stadium", "Admin");

        }

        [HttpGet]
        public IActionResult UpdateStadium(int id)
        {
            var value = _stadiumService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStadium(Stadium p, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin_panel", "img", fileName);
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                p.ImageURL = "/admin_panel/img/" + fileName;
            }

            _stadiumService.TUpdate(p);
            return RedirectToAction("Stadium", "Admin");
        }

    }
}
