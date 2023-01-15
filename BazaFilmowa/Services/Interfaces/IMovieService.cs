using BazaFilmowa.Entities;
using BazaFilmowa.Models;
using System.Collections.Generic;

namespace BazaFilmowa.Services
{
    public interface IMovieService
    {
        Movie GetMovieById(int id);
        void AddMovie(AddMovieDto addMovieDto);
        IEnumerable<Movie> GetMovies();
        void DeleteMovie(int id);
        void EditMovie(EditMovieDto editMovieDto);
    }
}