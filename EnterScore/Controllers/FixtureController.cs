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

        public IActionResult Index()
        {
            var values = _fixtureService.TGetFixtureWithTeams();
            return View(values);

           
    
        }
    }
}
