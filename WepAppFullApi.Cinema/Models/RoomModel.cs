namespace WepAppFullApi.Cinema.Models
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int CleanTimeMins { get; set; }
        public bool IsDeleted { get; set; }
        public List<ItemModel>? Technologies { get; set; }
        public List<RoomProjectionModel>? Projections { get; set; }
    }
}
