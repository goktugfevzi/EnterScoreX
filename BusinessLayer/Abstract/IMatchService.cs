using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMatchService : IGenericService<Match>
    {
        public List<Match> TGetMatchWithTeams();
        public List<Match> TGetMatchWithAllDetails();
        public Match TGetMatchWithTeamByID(int MatchID);
        public Match TGetMatchWithAllDetailsByID(int MatchID);

    }
}
