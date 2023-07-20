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
    public class PositionManager : IPositionService
    {
        IPositionDal _positionDal;

        public PositionManager(IPositionDal positionDal)
        {
            _positionDal = positionDal;
        }

        public void TDelete(Position t)
        {
            _positionDal.Delete(t);
        }

        public Position TGetById(int id)
        {
            return _positionDal.GetById(id);
        }

        public List<Position> TGetListAll()
        {
            return _positionDal.GetListAll();
        }

        public void TInsert(Position t)
        {
            _positionDal.Insert(t);
        }

        public void TUpdate(Position t)
        {
            _positionDal.Update(t);
        }
    }
}
