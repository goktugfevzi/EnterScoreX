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
    public class CoachManager : ICoachService
    {
        ICoachDal _CoachDal;

        public CoachManager(ICoachDal coachDal)
        {
            _CoachDal = coachDal;
        }

        public void TDelete(Coach t)
        {
           _CoachDal.Delete(t);
        }

        public Coach TGetById(int id)
        {
            return _CoachDal.GetById(id);   
        }

        public List<Coach> TGetListAll()
        {
         return  _CoachDal.GetListAll();
        }

        public void TInsert(Coach t)
        {
           _CoachDal.Insert(t);
        }

        public void TUpdate(Coach t)
        {
            _CoachDal.Update(t);
        }
    }
}
