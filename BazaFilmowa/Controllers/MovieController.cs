using BazaFilmowa.Models;
using BazaFilmowa.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Controllers
{
    [Route("api/movie")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("details/{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        public ActionResult GetMovieDetails([FromRoute] int id)
        {
            var movie = _movieService.GetMovieDetailsById(id);
            return Ok(movie);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        public ActionResult GetMovie([FromRoute] int id)
        {
            var movie = _movieService.GetMovieById(id);
            return Ok(movie);
        }


        [HttpGet]
        [SwaggerResponse(200)]
        [AllowAnonymous]
        public ActionResult GetMovies([FromQuery] PagingQuery pagingQuery, [FromQuery] SearchQuery searchQuery = null)
        {
            var movies = _movieService.GetMovies();
            return Ok(movies);
        }

        [HttpPost]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Add([FromBody] AddMovieDto addMovieDto)
        {
            _movieService.AddMovie(addMovieDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromQuery] int id)
        {
            _movieService.DeleteMovie(id);
            return Ok();
        }

        [HttpPut]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Edit([FromBody] EditMovieDto editMovieDto)
        {
            _movieService.EditMovie(editMovieDto);
            return Ok();
        }
    }
}
