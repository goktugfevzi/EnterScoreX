using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Result
    {
        public int ResultID { get; set; }

        public int MatchID { get; set; }
        public Match Match { get; set; }

        public int HomeTeamID { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamID { get; set; }
        public Team AwayTeam { get; set; }




    }
}
