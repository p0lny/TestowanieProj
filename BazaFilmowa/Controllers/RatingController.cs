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
    [Route("api/rating")]
    [ApiController]
    [Authorize]
    public class RatingController : ControllerBase
    {

        [HttpGet("overall/{movieId}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        public ActionResult GetOverallRating([FromRoute] int movieId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{movieId}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        public ActionResult GetUserRating([FromRoute] int movieId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public ActionResult Add([FromBody] AddRatingDto addRatingDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public ActionResult Delete([FromQuery] int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        public ActionResult Edit([FromBody] EditRatingDto editRatingDto)
        {
            throw new NotImplementedException();
        }
    }
}
