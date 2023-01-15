using BazaFilmowa.Models;

namespace BazaFilmowa.Services
{
    public interface IMovieService
    {
        void GetMovieById(int id);
        void AddMovie(AddMovieDto addMovieDto);
        object GetMovies();
        void DeleteMovie(int id);
        void EditMovie(EditMovieDto editMovieDto);
    }
}