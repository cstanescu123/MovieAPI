namespace MovieAPI.Models
{
    public class PostMovieRequest
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string LeadActor { get; set; }
        public string HeadDirector { get; set; }
    }
}
