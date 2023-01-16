using AutoMapper;
using BazaFilmowa.Entities;
using BazaFilmowa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Services
{
    public class CommentService : ICommentService
    {

        ApiDbContext _dbContext;
        IUserContextService _userContextService;
        IMapper _mapper;
        public CommentService(ApiDbContext dbContext, IUserContextService userContextService, IMapper mapper)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public void AddComment(AddCommentDto addCommentDto)
        {
            var comment = _mapper.Map<Comment>(addCommentDto);
            var userId = _userContextService.GetUserId;

            comment.UserId = userId ?? throw new Exception();

            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();

        }

        public IEnumerable<CommentDto> GetCommentsForMovie(int movieId)
        {
            var comments = _dbContext.Comments.Where(e => e.MovieId == movieId);
            var commentsDto = _mapper.Map<List<CommentDto>>(comments);

            return commentsDto;
            
        }
    }
}
