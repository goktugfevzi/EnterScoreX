using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PlayerManager : IPlayerService
    {
        IPlayerDal _playerDal;

        public PlayerManager(IPlayerDal playerDal)
        {
            _playerDal = playerDal;
        }

        public void TDelete(Player t)
        {
           _playerDal.Delete(t);
        }

        public Player TGetById(int id)
        {
            return _playerDal.GetById(id);  
        }

        public List<Player> TGetListAll()
        {
            return _playerDal.GetListAll();
        }

       

        public List<Player> TGetPlayersByTeamID(int id)
        {
            return _playerDal.GetPlayersByTeamID(id);
        }

      

        public void TInsert(Player t)
        {
            _playerDal.Insert(t);
        }

        public void TUpdate(Player t)
        {
          _playerDal.Update(t);
        }
    }
}
