using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık adı alanı boş geçilemez").MinimumLength(3).WithMessage("Başlık adı en az 3 karakter olmalı")
                .MaximumLength(30).WithMessage("Başlık adı en fazla 30 karakter olmalı");
            // kategori boş geçilemez hatası ver
            // yazar boş geçilemez hatası ver
        }
    }
}
