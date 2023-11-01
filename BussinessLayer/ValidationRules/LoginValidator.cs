using Entitiy.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class LoginValidator : AbstractValidator<Admin>
    {
        public LoginValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez").MinimumLength(5).WithMessage("En az 5 karakter olmalı")
                .MaximumLength(10).WithMessage("En fazla 10 karakter olmalı");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifre boş geçilemez").MinimumLength(5).WithMessage("En az 5 karakter olmalı")
                .MaximumLength(10).WithMessage("En fazla 10 karakter olmalı");
        }
    }
}
