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
    [Route("api/comments")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {

        ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [SwaggerResponse(200)]
        public ActionResult GetCommentsForMovie([FromQuery] int movieId, [FromQuery] PagingQuery pagingQuery)
        {
            var comments = _commentService.GetCommentsForMovie(movieId);
            return Ok(comments);
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
            _commentService.AddComment(addCommentDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        public ActionResult Delete([FromRoute] int id)
        {
            _commentService.DeleteComment(id);
            return Ok();
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
