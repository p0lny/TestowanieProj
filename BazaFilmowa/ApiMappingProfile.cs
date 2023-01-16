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
            CreateMap<EditMovieDto, Movie>();
            CreateMap<EditMovieDto, MovieDetails>();

            //comments
            CreateMap<Comment, CommentDto>();
            CreateMap<AddCommentDto, Comment>()
                .ForMember(e => e.PostedAt, m => m.MapFrom(s => DateTime.Now))
                .ForMember(e => e.SpoilerAlert, m => m.MapFrom(s => false))
                .ForMember(e => e.Moderated, m => m.MapFrom(s => true));
        }
    }
}
