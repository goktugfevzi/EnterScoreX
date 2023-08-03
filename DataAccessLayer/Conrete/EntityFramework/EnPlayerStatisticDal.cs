using DataAccessLayer.Abstract;
using DataAccessLayer.Conrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Conrete.EntityFramework
{
    public class EnPlayerStatisticDal : GenericRepository<PlayerStatistic>, IPlayerStatisticDal
    {
        public List<PlayerStatistic> GetPlayerByTeamID(int id)
        {
            var context = new EnterScoreXContext();
            return context.PlayerStatistics
                .Include(x => x.Player)
                .Include(x => x.Player.Position)
                .Where(x => x.Player.TeamID == id).ToList();
        }

    }
}
