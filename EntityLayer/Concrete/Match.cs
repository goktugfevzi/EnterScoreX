using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Match
    {

        public int MatchID { get; set; }

        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }
        public int? HomeTeamShots { get; set; }
        public int? AwayTeamShots { get; set; }
        public int? HomeTeamShotsOnTarget { get; set; }
        public int? AwayTeamShotsOnTarget { get; set; }
        public int? HomeTeamPassSuccess { get; set; }
        public int? AwayTeamPassSuccess { get; set; }
        public int? HomeTeamFoulCount { get; set; }
        public int? AwayTeamFoulCount { get; set; }
        public int? HomeTeamAirealDualSuccess { get; set; }
        public int? AwayTeamAirealDualSuccess { get; set; }



        public int? HomeTeamID { get; set; }
        public Team HomeTeam { get; set; }


        public int? AwayTeamID { get; set; }
        public Team AwayTeam { get; set; }


        public int? StadiumID { get; set; }
        public Stadium Stadium { get; set; }


        public int? RefereeID { get; set; }
        public Referee Referee { get; set; }


        public int? FixtureID { get; set; }
        public Fixture Fixture { get; set; }


        public virtual List<Goal> Goals { get; set; }

    }
}
