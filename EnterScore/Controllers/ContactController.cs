using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EnterScore.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SendMessageDto model)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.TInsert(new ContactUs()
                {
                    MessageBody = model.MessageBody,
                    Mail = model.Mail,
                    MessageStatus = true,
                    Name = model.Name,
                    SubjectTitle = model.SubjectTitle,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });

                // Gönderme işlemi başarılıysa başka bir sayfaya yönlendirebilirsiniz.
                // Örnek olarak HomeController içindeki bir action'a yönlendirelim:
                return RedirectToAction("ContactSuccess", "Home");
            }

            // Eğer model geçerli değilse, iletişim formunu tekrar gösterin.
            return View(model);
        }
    }
}
