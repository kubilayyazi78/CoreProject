using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş bırakılamaz...");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz...");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Kategori adı 50 karakterden fazla olmamalıdır...");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalıdır...");
        }
    }
}
