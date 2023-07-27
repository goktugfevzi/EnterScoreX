﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Team
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }




        public int CoachID { get; set; }
        public Coach Coach { get; set; }

        public int StadiumID { get; set; }
        public Stadium Stadium { get; set; }

        public virtual ICollection<Match> HomesMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }
        public virtual ICollection<Fixture> HomesResult { get; set; }
        public virtual ICollection<Fixture> AwayResult { get; set; }
        public virtual ICollection<Goal> GoalForTeam { get; set; }
        public virtual ICollection<Goal> GoalAgainstTeam { get; set; }
    }
}
