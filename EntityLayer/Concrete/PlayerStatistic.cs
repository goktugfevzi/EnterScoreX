using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PlayerStatistic
    {
        public int PlayerStatisticID { get; set; }
        public int GoalScore { get; set; }
        public int AsistScore { get; set; }


        public int PlayerID { get; set; }
        public Player Player { get; set; }
    }
}
