using AutoMapper;
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
        private readonly IMapper _mapper;
        public MovieService(ApiDbContext dbContext, IUserContextService userContextService, IMapper mapper)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public int AddMovie(AddMovieDto addMovieDto)
        {
            var movie = _mapper.Map<Movie>(addMovieDto);
            var movieDetails = _mapper.Map<MovieDetails>(addMovieDto);

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            movieDetails.MovieId = movie.Id;
            _dbContext.MovieDetails.Add(movieDetails);
            _dbContext.SaveChanges();

            return movie.Id;
        }

        public void DeleteMovie(int id)
        {
            if (!_dbContext.Movies.Any(e => e.Id == id))
            {
                throw new Exception();
            }

            var movie = _dbContext.Movies.FirstOrDefault(e => e.Id == id);
            var movieDetails = _dbContext.MovieDetails.FirstOrDefault(e => e.MovieId == id);

            if (movieDetails != null)
            {
                _dbContext.Remove(movieDetails);
            }

            if (movie != null)
            {
                _dbContext.Remove(movie);
            }

            _dbContext.SaveChanges();
        }

        public void EditMovie(EditMovieDto editMovieDto)
        {

            var movie = _dbContext.Movies.FirstOrDefault(e => e.Id == editMovieDto.Id);
            var movieDetails = _dbContext.MovieDetails.FirstOrDefault(e => e.MovieId == editMovieDto.Id);

            var updatedMovie = _mapper.Map<EditMovieDto,Movie>(editMovieDto, movie);
            var updatedMovieDetails = _mapper.Map<EditMovieDto,MovieDetails>(editMovieDto,movieDetails);
           
            _dbContext.Movies.Update(updatedMovie);
            _dbContext.MovieDetails.Update(updatedMovieDetails);
            _dbContext.SaveChanges();
        }

        public MovieDto GetMovieById(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(e => e.Id == id);
            var movieDto = _mapper.Map<MovieDto>(movie);
            return movieDto;
        }

        public MovieDetailsDto GetMovieDetailsById(int id)
        {
            var movieDetails = _dbContext.MovieDetails.FirstOrDefault(e => e.MovieId == id);
            var movieDetailsDto = _mapper.Map<MovieDetailsDto>(movieDetails);
            return movieDetailsDto;
        }

        public PagedResult<MovieDto> GetMovies(PagingQuery pagingQuery, string searchPhrase)
        {
            var movies =
                _dbContext.Movies
                .Where(e => searchPhrase == null || e.Title.ToLower().Contains(searchPhrase.ToLower()));

            var moviesPaged =
                movies.Skip(pagingQuery.PageSize * (pagingQuery.PageNumber - 1))
                .Take(pagingQuery.PageSize);

            var moviesCount = moviesPaged.Count();

            var moviesDtos = _mapper.Map<List<MovieDto>>(movies);

            var result = new PagedResult<MovieDto>(moviesDtos, moviesCount, pagingQuery.PageSize, pagingQuery.PageNumber);

            return result;
        }
    }
}
