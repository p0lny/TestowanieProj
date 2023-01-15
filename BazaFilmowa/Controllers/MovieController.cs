using BazaFilmowa.Models;
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
        
        [HttpGet("{id}")]
        [Authorize]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        public ActionResult Get([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerResponse(200)]
        public ActionResult GetAll([FromQuery] PagingQuery pagingQuery, [FromQuery] SearchQuery searchQuery = null)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [Authorize(Roles ="Admin,Moderator")]
        public ActionResult Add([FromBody] AddMovieDto addMovieDto)
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete("{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromQuery] int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
