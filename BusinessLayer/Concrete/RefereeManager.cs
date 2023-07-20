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
    public class RefereeManager : IRefereeService
    {
        IRefereeDal _refereeDal;

        public RefereeManager(IRefereeDal refereeDal)
        {
            _refereeDal = refereeDal;
        }

        public void TDelete(Referee t)
        {
            _refereeDal.Delete(t);
        }

        public Referee TGetById(int id)
        {
            return _refereeDal.GetById(id);
        }

        public List<Referee> TGetListAll()
        {
            return _refereeDal.GetListAll();
        }

        public void TInsert(Referee t)
        {
            _refereeDal.Insert(t);
        }

        public void TUpdate(Referee t)
        {
            _refereeDal.Update(t);
        }
    }
}
