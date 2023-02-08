namespace BazaFilmowa.Models
{
    public class SearchQuery
    {
        public string Title { get; set; } = "";
        public string Genre { get; set; } = "";
        public int Rating { get; set; } = 0;
    }
}