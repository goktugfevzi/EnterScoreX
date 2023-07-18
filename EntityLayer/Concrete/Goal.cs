using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Goal
    {
        public int GoalID { get; set; }
        public int GoalTime { get; set; }


        public int PlayerID { get; set; }
        public Player player { get; set; }


        public int MatchID { get; set; }
        public Match Match { get; set; }


    }
}
