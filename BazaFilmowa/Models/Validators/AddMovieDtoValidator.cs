using BazaFilmowa.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
               });
        }
    }
}
