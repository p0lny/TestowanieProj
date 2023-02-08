using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Models
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public bool SpoilerAlert { get; set; }
        public DateTime PostedAt { get; set; }
        public bool Moderated { get; set; }

    }
}
