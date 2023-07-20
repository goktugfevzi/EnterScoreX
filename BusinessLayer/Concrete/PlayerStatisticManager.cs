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
    public class PlayerStatisticManager : IPlayerStatisticService
    {
        IPlayerStatisticDal _playerStatisticDal;

        public PlayerStatisticManager(IPlayerStatisticDal playerStatisticDal)
        {
            _playerStatisticDal = playerStatisticDal;
        }

        public void TDelete(PlayerStatistic t)
        {
           _playerStatisticDal.Delete(t);   
        }

        public PlayerStatistic TGetById(int id)
        {
           return _playerStatisticDal.GetById(id);
        }

        public List<PlayerStatistic> TGetListAll()
        {
           return _playerStatisticDal.GetListAll();
        }

        public void TInsert(PlayerStatistic t)
        {
            _playerStatisticDal.Insert(t);
        }

        public void TUpdate(PlayerStatistic t)
        {
            _playerStatisticDal.Update(t);
        }
    }
}
