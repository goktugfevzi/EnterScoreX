using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Fixture
{
    
    public class _FixturePartial : ViewComponent
    {
        private readonly IMatchService _matchService;

        public _FixturePartial(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public IViewComponentResult Invoke() 
        {
            var x = _matchService.TGetMatchWithTeams();
               
            return View(x); 
        } 
    }
}
