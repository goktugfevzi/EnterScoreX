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
    public class SeasonManager : ISeasonService
    {
        ISeasonDal _seasonDal;

        public SeasonManager(ISeasonDal seasonDal)
        {
            _seasonDal = seasonDal;
        }

        public void TDelete(Season t)
        {
            _seasonDal.Delete(t);
        }

        public Season TGetById(int id)
        {
            return _seasonDal.GetById(id);
        }

        public List<Season> TGetListAll()
        {
            return _seasonDal.GetListAll();
        }

        public void TInsert(Season t)
        {
           _seasonDal.Insert(t);
        }

        public void TUpdate(Season t)
        {
           _seasonDal.Update(t);
        }
    }
}
