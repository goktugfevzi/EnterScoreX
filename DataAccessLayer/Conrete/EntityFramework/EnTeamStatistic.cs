using DataAccessLayer.Abstract;
using DataAccessLayer.Conrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Conrete.EntityFramework
{
    public class EnTeamStatisticDal : GenericRepository<TeamStatistic>, ITeamStatisticDal
    {
    }
}
