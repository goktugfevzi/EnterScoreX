using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Conrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICoachService, CoachManager>();
            services.AddScoped<ICoachDal, EnCoachDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EnContactDal>();

            services.AddScoped<IFixtureService, FixtureManager>();
            services.AddScoped<IFixtureDal, EnFixtureDal>();

            services.AddScoped<IGoalService, GoalManager>();
            services.AddScoped<IGoalDal, EnGoalDal>();

            services.AddScoped<IMatchService, MatchManager>();
            services.AddScoped<IMatchDal, EnMatchDal>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EnMessageDal>();

            services.AddScoped<IPlayerService, PlayerManager>();
            services.AddScoped<IPlayerDal, EnPlayerDal>();

            services.AddScoped<IPlayerStatisticService, PlayerStatisticManager>();
            services.AddScoped<IPlayerStatisticDal, EnPlayerStatisticDal>();

            services.AddScoped<IPositionService, PositionManager>();
            services.AddScoped<IPositionDal, EnPositionDal>();

            services.AddScoped<IRefereeService, RefereeManager>();
            services.AddScoped<IRefereeDal, EnRefereeDal>();

            services.AddScoped<ITeamService, TeamManager>();
            services.AddScoped<ITeamDal, EnTeamDal>();

            services.AddScoped<ISeasonService, SeasonManager>();
            services.AddScoped<ISeasonDal, EnSeasonDal>();

            services.AddScoped<IStadiumService, StadiumManager>();
            services.AddScoped<IStadiumDal, EnStadiumDal>();

            services.AddScoped<ITeamStatisticService, TeamStatisticManager>();
            services.AddScoped<ITeamStatisticDal, EnTeamStatisticDal>();

        }
    }
}
