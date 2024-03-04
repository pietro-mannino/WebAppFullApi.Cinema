using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WepAppFullApi.Cinema.Data
{
    [PrimaryKey(nameof(EmployeeId), nameof(ActivityRoleId), nameof(ProjectionId))]
    public class ProjectionActivity
    {
        public int ActivityRoleId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectionId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Employee? Employee { get; set; }
        public Projection? Projection { get; set; }
        public ActivityRole? ActivityRole { get; set; }
    }
}
