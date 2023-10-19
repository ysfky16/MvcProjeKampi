using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {

            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı en az 2 Karakter olmalı");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı en fazla 50 Karakter olmalı");
            RuleFor(x => x.WriterSurmame).NotEmpty().WithMessage("Yazar soyadı boş geçilemez");
            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez");  // hakkında kısmı a harfi içerneli yap !!
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Etiket kısmı boş geçilemez");
           


        }
    }
}
