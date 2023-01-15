using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }
        public bool SpoilerAlert { get; set; }
        public DateTime PostedAt { get; set; }
        public bool Moderated { get; set; }



        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
