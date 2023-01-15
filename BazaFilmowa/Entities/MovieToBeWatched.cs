using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Entities
{
    public class MovieToBeWatched
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }


        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
