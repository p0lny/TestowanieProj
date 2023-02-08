namespace BazaFilmowa.Models
{
    public class ModerateCommentDto
    {
        public int MovieId { get; set; }
        public int CommentId { get; set; }
        public int Comment { get; set; }
        public bool RecommendsMovie { get; set; }
        public bool Moderated { get; set; }
        public bool SpoilerAlert { get; set; } = false;
    }
}