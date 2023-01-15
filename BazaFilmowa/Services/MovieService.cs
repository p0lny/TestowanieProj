using BazaFilmowa.Entities;
using BazaFilmowa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Services
{
    public class MovieService : IMovieService
    {
        public readonly IUserContextService _userContextService;
        private readonly ApiDbContext _dbContext;
        public MovieService(ApiDbContext dbContext, IUserContextService userContextService,)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
        }

        public void AddMovie(AddMovieDto addMovieDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public void EditMovie(EditMovieDto editMovieDto)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(e => e.Id == id);
            return movie;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var movies = _dbContext.Movies.ToList();
            return movies;
        }
    }
}
