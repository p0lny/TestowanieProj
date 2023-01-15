using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Services
{
    public class MovieService : IMovieService
    {
        public readonly IUserContextService _userContextService;
        public MovieService(IUserContextService userContextService)
        {
            _userContextService = userContextService;
        }


    }
}
