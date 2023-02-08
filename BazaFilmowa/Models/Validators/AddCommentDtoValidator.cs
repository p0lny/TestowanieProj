using BazaFilmowa.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Models.Validators
{
    public class AddCommentDtoValidator:AbstractValidator<AddCommentDto>
    {
        public AddCommentDtoValidator(ApiDbContext dbContext)
        {
            RuleFor(e => e.MovieId)
                .Custom((value, contex) =>
                {
                    var movieAlreadyExists = dbContext.Movies.Any(e => e.Id == value);

                    if (!movieAlreadyExists)
                    {
                        contex.AddFailure("No movie for given id", "There is no movie with the given id");
                    }
                });
        }
    }
}
