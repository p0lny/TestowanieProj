using System;
using System.Collections.Generic;

namespace BazaFilmowa.Models
{
    public class AddMovieDto
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime PremiereDate { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public string ProductionLocation { get; set; }
        public string Language { get; set; }
        public int? AgeRestriction { get; set; }
        public string Description { get; set; }
        public string UrlPoster { get; set; }
        public string UrlTrailer { get; set; }
    }
}