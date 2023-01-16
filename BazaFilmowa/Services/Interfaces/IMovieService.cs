using BazaFilmowa.Entities;
using BazaFilmowa.Models;
using System.Collections.Generic;

namespace BazaFilmowa.Services
{
    public interface IMovieService
    {
        MovieDto GetMovieById(int id);
        void AddMovie(AddMovieDto addMovieDto);
        IEnumerable<MovieDto> GetMovies();
        void DeleteMovie(int id);
        void EditMovie(EditMovieDto editMovieDto);
        MovieDetailsDto GetMovieDetailsById(int id);
    }
}