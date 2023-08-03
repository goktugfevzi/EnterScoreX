using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EnterScore.Services;
using EnterScore.ViewComponents.ClubsList;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterScore.ViewComponents.Profiles
{
    public class _ProfilesPartial : ViewComponent
    {
        private readonly IPlayerService _playerService;
        private readonly ICloudStorageService _cloudStorageService;


        public _ProfilesPartial(IPlayerService playerService, ICloudStorageService cloudStorageService)
        {
            _playerService = playerService;
            _cloudStorageService = cloudStorageService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = (int)TempData["id"];
            var value = _playerService.TGetPlayerWithTeam(id);
            await GenerateSignedUrl(value);
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




