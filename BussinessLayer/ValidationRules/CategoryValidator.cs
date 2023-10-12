using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {

        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori ismi boş geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori ismi en az 3 karakter olmalı");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori ismi en fazla 20 karakter olmalı");
        }
    }
}
