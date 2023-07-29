using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Result
{
   
    public class _MatchTodayPartial : ViewComponent
    {
        private readonly IMatchService _matchService;

        public _MatchTodayPartial(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public IViewComponentResult Invoke() 
        { 
            var values = _matchService.TGetMatchWithTeams();
            return View(values); 
        } 
    }
}
