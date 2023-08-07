using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TeamStatistic
    {
        public int TeamStatisticID { get; set; }
        public int? GoalsFor { get; set; }
        public int? GoalsAgainst { get; set; }
        public int? Points { get; set; }
        public int? PlayedCount { get; set; }
        public int? WinCount { get; set; }
        public int? LoseCount { get; set; }
        public int? DrawCount { get; set; }
        public int? Average { get; set; }

        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}
