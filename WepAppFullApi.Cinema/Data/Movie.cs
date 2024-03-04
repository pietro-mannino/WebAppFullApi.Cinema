using System.ComponentModel.DataAnnotations;

namespace WepAppFullApi.Cinema.Data
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ImdbId { get; set; }
        public int AgeLimitId { get; set; }
        public int DurationMins { get; set; }
        public bool IsDeleted { get; set; } = false;
        public AgeLimit? AgeLimit { get; set; }
        public List<Technology>? Technologies { get; set; }
        public List<Projection>? Projections { get; set;}
    }
}
