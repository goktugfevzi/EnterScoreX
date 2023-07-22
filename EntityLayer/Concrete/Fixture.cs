using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Fixture
    {
        public int FixtureID { get; set; }
        public int Week { get; set; }
        public bool WeekCompleted { get; set; }


        public int SeasonID { get; set; }
        public Season Season { get; set; }

        public int HomeTeamID { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamID { get; set; }
        public Team AwayTeam { get; set; }




    }
}
