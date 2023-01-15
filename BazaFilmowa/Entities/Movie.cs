using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlPoster { get; set; }
        public string UrlTrailer { get; set; }


        public IEnumerable<UserMovieRating> UserMovieRatings { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual IEnumerable<MovieGenre> MovieGenres { get; set; }
        public virtual MovieDetails MovieDetails { get; set; }
    }
}

