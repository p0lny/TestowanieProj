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
    [Route("api/watchlist")]
    [ApiController]
    public class WatchListController : ControllerBase
    {

        [HttpGet("watched")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        public ActionResult GetAllAlreadyWatched([FromQuery] PagingQuery pagingQuery, [FromQuery] SearchQuery searchQuery = null)
        {
            throw new NotImplementedException();
        }

        [HttpPost("watched")]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public ActionResult AddAlreadyWatched([FromBody] AddAlreadyWatchedDto addAlreadyWatchedDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("watched/{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(403)]
        [SwaggerResponse(401)]
        public ActionResult DeleteAlreadyWatched([FromQuery] int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("tobewatched")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        public ActionResult GetAllToBeWatched([FromQuery] PagingQuery pagingQuery, [FromQuery] SearchQuery searchQuery = null)
        {
            throw new NotImplementedException();
        }

        [HttpPost("tobewatched")]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public ActionResult AddToBeWatched([FromBody] AddToBeWatchedDto addToBeWatchedDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("tobewatched/{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public ActionResult DeleteToBeWatched([FromQuery] int id)
        {
            throw new NotImplementedException();
        }


    }
}
