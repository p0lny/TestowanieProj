using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual IEnumerable<MovieGenre> MovieGenres { get; set; }
    }
}
