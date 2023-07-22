using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Conrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FixtureManager : IFixtureService
    {
        IFixtureDal _fixtureDal;

        public FixtureManager(IFixtureDal fixtureDal)
        {
            _fixtureDal = fixtureDal;
        }

        public void TDelete(Fixture t)
        {
            _fixtureDal.Delete(t);
        }

        public Fixture TGetById(int id)
        {
            return _fixtureDal.GetById(id);
        }

        public List<Fixture> TGetFixtureWithTeams()
        {
            return _fixtureDal.GetFixtureWithTeams();
        }

        public List<Fixture> TGetListAll()
        {
            return _fixtureDal.GetListAll();
        }

        public void TInsert(Fixture t)
        {
            _fixtureDal.Insert(t);
        }

        public void TUpdate(Fixture t)
        {
            _fixtureDal.Update(t);
        }
    }
}
