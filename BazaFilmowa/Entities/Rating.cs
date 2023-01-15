using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Entities
{
    public class Rating
    {
        public int MovieId { get; set; }
        public double AverageRating { get; set; }
        public int VotesNumber { get; set; }



        public virtual Movie Movie { get; set; }
    }
}
