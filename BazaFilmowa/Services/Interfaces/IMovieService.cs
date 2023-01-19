using BazaFilmowa.Entities;
using BazaFilmowa.Models;
using System.Collections.Generic;

namespace BazaFilmowa.Services
{
    public interface IMovieService
    {
        MovieDto GetMovieById(int id);
        int AddMovie(AddMovieDto addMovieDto);
        PagedResult<MovieDto> GetMovies(PagingQuery pagingQuery, string searchPhrase);
        void DeleteMovie(int id);
        void EditMovie(EditMovieDto editMovieDto);
        MovieDetailsDto GetMovieDetailsById(int id);
    }
}