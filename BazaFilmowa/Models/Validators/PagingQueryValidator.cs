using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Models.Validators
{
    public class PagingQueryValidator : AbstractValidator<PagingQuery>
    {
        private int[] allowedPageSizes = new[] { 10, 25, 50 };
        public PagingQueryValidator()
        {
            RuleFor(e => e.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(e => e.PageSize).Custom((value, context) =>
              {
                  if (!allowedPageSizes.Contains(value))
                  {
                      context.AddFailure("PageSize", $"Allowed page sizes:{string.Join(",", allowedPageSizes)}");
                  }
              });
        }
    }
}
