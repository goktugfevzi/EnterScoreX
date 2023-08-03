﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPlayerService : IGenericService<Player>
    {
        public List<Player> TGetPlayersByTeamID(int id);
        public Player TGetPlayerWithTeam(int id);




    }
}
