namespace BazaFilmowa.Models
{
    public class AddCommentDto
    {
        public int MovieId { get; set; }
        public string Comment { get; set; }       
        public bool RecommendsMovie { get; set; }
    }
}