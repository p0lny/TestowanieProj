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
        public ActionResult GetMovies([FromQuery] PagingQuery pagingQuery, [FromQuery] string searchPhrase = null)
        {
            var movies = _movieService.GetMovies(pagingQuery, searchPhrase);
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
            var id = _movieService.AddMovie(addMovieDto);
            return Created($"/api/movie/{id}", null);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int id)
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
