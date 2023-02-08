using BazaFilmowa.Entities;
using FluentValidation;
using System.Linq;

namespace BazaFilmowa.Models.Validators
{
    public class AddMovieDtoValidator : AbstractValidator<AddMovieDto>
    {
        public AddMovieDtoValidator(ApiDbContext dbContext)
        {
            RuleFor(e => e.Title)
               .Custom((value, contex) =>
               {
                   var movieAlreadyExists = dbContext.Movies.Any(e => e.Title == value);

                   if (movieAlreadyExists)
                   {
                       contex.AddFailure("Movie", "Movie with this title already exists in database.");
                   }
               })
                .NotEmpty()
                .NotNull();

            RuleFor(e=>e.UrlPoster)
                .NotEmpty()
                .NotNull();

            RuleFor(e=>e.UrlTrailer)
                .NotEmpty()
                .NotNull();
        }
    }
}
