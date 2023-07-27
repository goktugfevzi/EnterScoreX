using DTOLayer.DTOs.ContactUsDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.SubjectTitle).NotEmpty().WithMessage("Konu alanı boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj alanı boş geçilemez");
            RuleFor(x => x.SubjectTitle).MinimumLength(5).WithMessage("Konu Başlığına en az 5 karakter veri girişi yapmanız gerekli");
            RuleFor(x => x.SubjectTitle).MaximumLength(100).WithMessage("Konu Başlığına en fazla 20 karakter veri girişi yapabilirsiniz");
            RuleFor(x => x.MessageBody).MinimumLength(20).WithMessage("Mesaj alanına en az 5 karakter veri girişi yapmanız gerekli");
            RuleFor(x => x.MessageBody).MaximumLength(100).WithMessage("Mail alanına en fazla 50 karakter veri girişi yapabilirsiniz");
        }
    }
}
