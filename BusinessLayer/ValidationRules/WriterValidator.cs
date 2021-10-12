using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar Adı Soyadı Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("2 karakterden fazla olmalı");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("En fazla 50 karakter olabilir");
        }
    }
}
