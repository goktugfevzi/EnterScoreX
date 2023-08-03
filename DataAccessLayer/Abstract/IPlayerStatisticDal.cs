using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPlayerStatisticDal : IGenericDal<PlayerStatistic>
    {
        public List<PlayerStatistic> GetPlayerByTeamID(int id);

    }
}
