using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutDetails1).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.AboutDetails2).NotEmpty().WithMessage("Açıklam alanı boş geçilemez").MinimumLength(10).WithMessage("En az 10 karakter giriniz");
        }
    }
}
