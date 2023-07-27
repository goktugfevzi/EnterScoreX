using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterScore.ViewComponents.Profiles
{
    public class _ProfilesPartial:ViewComponent
    {
        private readonly IPlayerService _playerService;

        public _ProfilesPartial(IPlayerService playerService)
        {
            _playerService = playerService;
        }

       
            public IViewComponentResult Invoke()
            {
                var player = _playerService.TGetListAll();
                return View(player);
            }
        
      
    }
}
