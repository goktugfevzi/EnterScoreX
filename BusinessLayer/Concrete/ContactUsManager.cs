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
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _ContactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _ContactUsDal = contactUsDal;
        }

        public void TDelete(ContactUs t)
        {
           _ContactUsDal.Delete(t);
        }

        public ContactUs TGetById(int id)
        {
           return _ContactUsDal.GetById(id);
        }

        public List<ContactUs> TGetListAll()
        {
            return _ContactUsDal.GetListAll();
        }

        public void TInsert(ContactUs t)
        {
           _ContactUsDal.Insert(t);
        }

        public void TUpdate(ContactUs t)
        {
      _ContactUsDal.Update(t);
        }
    }
}
