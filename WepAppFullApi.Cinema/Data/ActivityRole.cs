namespace WepAppFullApi.Cinema.Data
{
    public class ActivityRole
    {
        public int ActivityRoleId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<ProjectionActivity>? ProjectionActivities { get; set; }
    }

    public class ActivityRoleJson
    {
        public string name { get; set; }
    }

}
