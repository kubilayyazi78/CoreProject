using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog Başlığı Boş Geçilemez...");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog İçeriği Boş Geçilemez...");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Blog Görseli Boş Geçilemez...");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık en az 5 karakter olabilir");
        }
    }
}
