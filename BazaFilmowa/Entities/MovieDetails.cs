using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Entities
{
    public class MovieDetails
    {
        public int MovieId { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime PremiereDate { get; set; }
        public string ProductionLocation { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public short AgeRestriction { get; set; }


        public virtual Movie Movie { get; set; }
    }
}
