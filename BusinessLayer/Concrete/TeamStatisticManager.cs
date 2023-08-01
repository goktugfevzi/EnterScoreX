using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Conrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TeamStatisticManager : ITeamStatisticService
    {
        ITeamStatisticDal _teamStatisticDal;

        public TeamStatisticManager(ITeamStatisticDal teamStatisticDal)
        {
            _teamStatisticDal = teamStatisticDal;
        }

        public void TDelete(TeamStatistic t)
        {
            _teamStatisticDal.Delete(t);
        }

        public TeamStatistic TGetById(int id)
        {
            return _teamStatisticDal.GetById(id);
        }

        public List<TeamStatistic> TGetListAll()
        {
            return _teamStatisticDal.GetListAll();
        }

        public void TInsert(TeamStatistic t)
        {
            _teamStatisticDal.Insert(t);
        }

        public void TUpdate(TeamStatistic t)
        {
            _teamStatisticDal.Update(t);
        }
        public List<TeamStatistic> TGetTeamStatisticWithTeams()
        {
            return _teamStatisticDal.GetTeamStatisticWithTeams();
        }

    }
}
