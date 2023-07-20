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
    public class GoalManager : IGoalService
    {
        IGoalDal _goalDal;

        public GoalManager(IGoalDal goalDal)
        {
            _goalDal = goalDal;
        }

        public void TDelete(Goal t)
        {
          _goalDal.Delete(t);
        }

        public Goal TGetById(int id)
        {
           return _goalDal.GetById(id);
        }

        public List<Goal> TGetListAll()
        {
            return _goalDal.GetListAll();
        }

        public void TInsert(Goal t)
        {
            _goalDal.Insert(t);
        }

        public void TUpdate(Goal t)
        {
         _goalDal.Update(t);
        }
    }
}
