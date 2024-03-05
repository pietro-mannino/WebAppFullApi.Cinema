namespace WepAppFullApi.Cinema.Models
{
    public class RoomProjectionModel
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Start { get; set; }
        public DateTime FreeBy { get; set; }
    }
}
