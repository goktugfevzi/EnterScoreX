using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMatchDal : IGenericDal<Match>
    {
        public List<Match> GetMatchWithTeams();
        public List<Match> GetMatchWithAllDetails();
        public Match GetMatchWithTeamByID(int MatchID);
        public Match GetMatchWithAllDetailsByID(int MatchID);
        public List<Match> GetTeamLastMatches(int id);
    }
}
