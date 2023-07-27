using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{

    public class ProfilesTrailController : Controller
    {
           private readonly IPlayerService _playerService;

        public ProfilesTrailController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public IActionResult Index(int id)
        {
          ViewBag.p = id;
            var values = _playerService.TGetById(id);
            return View(values);
        }
    }
}
