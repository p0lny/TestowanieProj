using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Models.Validators
{
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty();

            RuleFor(e => e.Password)
                .NotEmpty();
        }
    }
}
