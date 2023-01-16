using BazaFilmowa.Models;
using System.Collections;
using System.Collections.Generic;

namespace BazaFilmowa.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentDto> GetCommentsForMovie(int movieId);
        void AddComment(AddCommentDto addCommentDto);
    }
}