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
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        [HttpGet]
        [SwaggerResponse(200)]
        public ActionResult GetAll([FromQuery] int movieId, [FromQuery] PagingQuery pagingQuery)
        {
            throw new NotImplementedException();
        }

        [HttpGet("history/{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        public ActionResult GetHistory([FromRoute] int id)
        {
            throw new NotImplementedException();
        }
       
        [HttpPost]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public ActionResult Add([FromBody] AddCommentDto addCommentDto)
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

        [HttpPut("edit")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        public ActionResult Edit([FromBody] EditCommentDto editCommentDto)
        {
            throw new NotImplementedException();
        }

        [HttpPut("moderate")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        public ActionResult ModerateComment([FromBody] ModerateCommentDto moderateCommentDto)
        {
            throw new NotImplementedException();
        }
    }
}
