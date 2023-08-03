﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITeamService : IGenericService<Team>
    {
        public List<Team> TGetTeamsWithCoach();
        public List<Team> TGetTeamsWithStatistics();
        public Team TGetTeamWithCoachById(int id);


    }
}
