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
    public class EnPlayerDal : GenericRepository<Player>, IPlayerDal
    {


        public List<Player> GetPlayersByTeamID(int id)
        {
            var context = new EnterScoreXContext();
            return context.Players.Where(x => x.TeamID == id).ToList();
        }

        public Player GetPlayerWithTeam(int id)
        {
            var context = new EnterScoreXContext();
            return context.Players.Include(x => x.Team).Where(x => x.PlayerID == id).FirstOrDefault();
        }

    }
}
