using BazaFilmowa.Models;
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
    public class MovieController : ControllerBase
    {
        
        [HttpGet("{id}")]
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
        public ActionResult Add([FromBody] AddMovieDto addMovieDto)
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete("{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
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
        public ActionResult Edit([FromBody] EditMovieDto editMovieDto)
        {
            throw new NotImplementedException();
        }
    }
}
