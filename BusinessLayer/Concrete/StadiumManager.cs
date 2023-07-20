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
    public class StadiumManager : IStadiumService
    {
        IStadiumDal _stadiumDal;

        public StadiumManager(IStadiumDal stadiumDal)
        {
            _stadiumDal = stadiumDal;
        }

        public void TDelete(Stadium t)
        {
         _stadiumDal.Delete(t);
        }

        public Stadium TGetById(int id)
        {
            return _stadiumDal.GetById(id);
        }

        public List<Stadium> TGetListAll()
        {
           return _stadiumDal.GetListAll();
        }

        public void TInsert(Stadium t)
        {
          _stadiumDal.Insert(t);
        }

        public void TUpdate(Stadium t)
        {
            _stadiumDal.Update(t);
        }
    }
}
