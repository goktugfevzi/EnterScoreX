using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IFixtureDal : IGenericDal<Fixture>
    {
        public List<Fixture> GetFixtureWithTeams();

        public List<Fixture> GetMatchesWithTeams();
        public List<List<Fixture>> GetFixtureWithTeamsGroupByWeek();

        public List<int> GetDistinctWeeks();


    }
}
