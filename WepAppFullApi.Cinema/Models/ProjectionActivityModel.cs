using Microsoft.EntityFrameworkCore;
using WepAppFullApi.Cinema.Data;
namespace WepAppFullApi.Cinema.Models
{
    [PrimaryKey(nameof(EmployeeId), nameof(ActivityRoleId), nameof(ProjectionId))]
    public class ProjectionActivityModel
    {
        public int ActivityRoleId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectionId { get; set; }
        public bool IsDeleted { get; set; }
        public string EmployeeName { get; set;}
        public string EmployeeSurame { get; set; }
        public string RoleName { get;set; }
    }
}
