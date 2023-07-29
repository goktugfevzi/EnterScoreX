using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFixtureService : IGenericService<Fixture>
    {
        public List<Fixture> TGetFixtureWithTeams();

       public List<Fixture> TGetMatchesWithTeams();

        public List<int> TGetDistinctWeeks();

    }
}
