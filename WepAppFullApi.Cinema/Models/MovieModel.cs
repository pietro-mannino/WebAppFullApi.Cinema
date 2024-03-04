using System.ComponentModel.DataAnnotations;
using WepAppFullApi.Cinema.Data;

namespace WepAppFullApi.Cinema.Models
{
    public class MovieModel
    {
        public int MovieId { get; set; }
        public required string Title { get; set; }
        [RegularExpression("^(tt[0-9]{7})$")]
        public required string ImdbId { get; set; }
        public int AgeLimitId { get; set; }
        public string? AgeLimit { get; set; }
        public int DurationMins { get; set; }
        public bool IsDeleted { get; set; }
        public List<ItemModel>? Technologies { get; set; }
        public List<MovieProjectionModel>? Projections { get; set; }
    }
}
