using BazaFilmowa.Entities;
using FluentValidation;
using System.Linq;

namespace BazaFilmowa.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(ApiDbContext dbContext)
        {

            RuleFor(e => e.Name)
                .NotEmpty();

            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(e => e.Password)
                .MinimumLength(6);

            RuleFor(e => e.PasswordConfirmation)
                .Equal(e => e.Password);

            RuleFor(e => e.Email)
                .Custom((value, contex) =>
                {
                    var isEmailAlreadyTaken = dbContext.Users.Any(e => e.Email == value);

                    if (isEmailAlreadyTaken)
                    {
                        contex.AddFailure("Email", "Email is already taken.");
                    }
                });


        }
    }
}
