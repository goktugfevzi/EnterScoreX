using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPlayerDal : IGenericDal<Player>
    {
        public List<Player> GetPlayersByTeamID(int id);
        public Player GetPlayerWithTeam(int id);




    }
}
