using WepAppFullApi.Cinema.Data;

namespace WepAppFullApi.Cinema.Models
{
    public class ProjectionModel
    {
        public int ProjectionId { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime Start { get; set; }
        public DateTime FreeBy { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProjectionActivityModel>? Activities { get; set; }
    }
}
