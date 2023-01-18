using AutoMapper;
using BazaFilmowa.Entities;
using BazaFilmowa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa
{
    public class ApiMappingProfile : Profile
    {

        public ApiMappingProfile()
        {
            //movies
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDetails, MovieDetailsDto>();
            CreateMap<AddMovieDto, Movie>();
            CreateMap<AddMovieDto, MovieDetails>();
            CreateMap<EditMovieDto, Movie>()
                .ForMember(e => e.Id, m => m.Ignore());
            CreateMap<EditMovieDto, MovieDetails>()
                .ForMember(e => e.Id, m => m.Ignore())
                .ForMember(e => e.MovieId, m => m.Ignore());

            //comments
            CreateMap<Comment, CommentDto>()
                .ForMember(e => e.UserName, m => m.MapFrom(s => $"{s.User.Name} {s.User.Surname}"));
            CreateMap<AddCommentDto, Comment>()
                .ForMember(e => e.CommentText, m => m.MapFrom(s => s.Comment))
                .ForMember(e => e.PostedAt, m => m.MapFrom(s => DateTime.Now))
                .ForMember(e => e.SpoilerAlert, m => m.MapFrom(s => false))
                .ForMember(e => e.Moderated, m => m.MapFrom(s => true));
        }
    }
}
