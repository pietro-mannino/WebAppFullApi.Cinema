using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace WepAppFullApi.Cinema.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }
        public DbSet<ActivityRole> ActivityRoles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<AgeLimit> AgeLimits { get; set; }
        public DbSet<ProjectionActivity> ProjectionActivities { get; set; }
    }
}
