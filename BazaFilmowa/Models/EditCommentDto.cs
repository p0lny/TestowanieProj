namespace BazaFilmowa.Models
{
    public class EditCommentDto
    {
        public int MovieId { get; set; }
        public int CommentId { get; set; }
        public int Comment { get; set; }
        public bool RecommendsMovie { get; set; }

    }
}