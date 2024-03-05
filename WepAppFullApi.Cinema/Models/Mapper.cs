using Microsoft.EntityFrameworkCore.Query;
using WepAppFullApi.Cinema.Data;

namespace WepAppFullApi.Cinema.Models
{
    public class Mapper
    {
        public ItemModel MapEntityToModel(Employee entity)
        {
            ItemModel model = new ItemModel()
            {
                Id = entity.EmployeeId,
                Name = entity.Name,
                Description = entity.Surname,
                IsDeleted = entity.IsDeleted

            };
            return model;
        }
        public Employee MapModelToEmployeeEntity(ItemModel model)
        {
            Employee entity = new Employee()
            {
                EmployeeId= model.Id,
                Name = model.Name,
                Surname = model.Description,
                IsDeleted = model.IsDeleted
            };
            return entity;
        }
        public MovieModel MapEntityToModel(Movie entity)
        {
            MovieModel model = new MovieModel()
            {
                MovieId = entity.MovieId,
                Title = entity.Title,
                AgeLimitId = entity.AgeLimitId,
                AgeLimit = entity.AgeLimit?.Description,
                DurationMins = entity.DurationMins,
                IsDeleted = entity.IsDeleted,
                ImdbId = entity.ImdbId,
                Technologies = entity.Technologies?.ConvertAll(MapEntityToModel),
                Projections = entity.Projections?.ConvertAll(MapEntityToMovieProjectionModel)
            };
            return model;
        }
        public MovieProjectionModel MapEntityToMovieProjectionModel(Projection entity)
        {
            MovieProjectionModel model = new MovieProjectionModel()
            {
                Id = entity.ProjectionId,
                FreeBy = entity.FreeBy,
                Start = entity.Start,
                RoomId = entity.RoomId,
                RoomName = entity.Room?.Name,
                IsDeleted = entity.IsDeleted
            };
            return model;
        }
        public Movie MapModelToEntity(MovieModel model)
        {
            Movie movie = new Movie()
            {
                MovieId = model.MovieId,
                Title = model.Title,
                ImdbId = model.ImdbId,
                AgeLimitId = model.AgeLimitId,
                DurationMins = model.DurationMins,
                IsDeleted = model.IsDeleted
                
            };
            return movie;
        }
        public ProjectionModel MapEntityToFullModel(Projection entity)
        {
            ProjectionModel model = new ProjectionModel()
            {
                ProjectionId = entity.ProjectionId,
                MovieId = entity.MovieId,
                MovieTitle = entity.Movie.Title,
                RoomId = entity.RoomId,
                RoomName = entity.Room.Name,
                IsDeleted = entity.IsDeleted,
                Start = entity.Start,
                FreeBy = entity.FreeBy,
                Activities = entity.Activities?.ConvertAll(MapEntityToModel)
            };
            return model;
        }
        public Projection MapModelToEntity(ProjectionModel model)
        {
            Projection entity = new Projection()
            {
                ProjectionId = model.ProjectionId,
                MovieId= model.MovieId,
                RoomId= model.RoomId,
                Start = model.Start,
                IsDeleted= model.IsDeleted,
                FreeBy = model.FreeBy,
            };
            return entity;
        }
        public ProjectionActivityModel MapEntityToModel(ProjectionActivity entity)
        {
            ProjectionActivityModel model = new ProjectionActivityModel()
            {
                ActivityRoleId = entity.ActivityRoleId,
                EmployeeId = entity.EmployeeId,
                ProjectionId = entity.ProjectionId,
                EmployeeName = entity.Employee.Name,
                EmployeeSurame = entity.Employee.Surname,
                RoleName = entity.ActivityRole.Description
            };
            return model;
        }
        public ItemModel MapEntityToModel(Technology entity)
        {
            ItemModel model = new ItemModel()
            {
                Id = entity.TechnologyId,
                Name = entity.Name,
                Description = entity.TechnologyType,
                IsDeleted = entity.IsDeleted
            };
            return model;
        }
        public Technology MapModelToTechnologyEntity(ItemModel model)
        {
            Technology entity = new Technology()
            {
                TechnologyId = model.Id,
                Name = model.Name,
                TechnologyType = model.Description,
                IsDeleted = model.IsDeleted,
            };
            return entity;
        }
        public ItemModel MapEntityToModel(AgeLimit entity)
        {
            ItemModel model = new ItemModel()
            {
                Id = entity.AgeLimitId,
                Name = entity.Description,
                IsDeleted = entity.IsDeleted
            };
            return model;
        }
        public AgeLimit MapModelToAgeLimitEntity(ItemModel model)
        {
            AgeLimit entity = new AgeLimit()
            {
                AgeLimitId = model.Id,
                Description = model.Name,
                IsDeleted = model.IsDeleted,
            };
            return entity;
        }
        public ItemModel MapEntityToModel(ActivityRole entity)
        {
            ItemModel model = new ItemModel()
            {
                Id = entity.ActivityRoleId,
                Name = entity.Description,
                IsDeleted = entity.IsDeleted,
            };
            return model;
        }
        public ActivityRole MapModelToActivityRoleEntity(ItemModel model)
        {
            ActivityRole entity = new ActivityRole()
            {
                ActivityRoleId = model.Id,
                Description = model.Name,
                IsDeleted = model.IsDeleted,
            };
            return entity;
        }
        public RoomModel MapEntityToModel(Room entity)
        {
            RoomModel model = new RoomModel()
            {
                RoomId = entity.RoomId,
                Name = entity.Name,
                CleanTimeMins = entity.CleanTimeMins,
                IsDeleted = entity.IsDeleted,
                Projections = entity.Projections?.ConvertAll(MapEntityToRoomProjectionModel),
                Technologies = entity.Technologies?.ConvertAll(MapEntityToModel),
            };
            return model;
        }
        public RoomProjectionModel MapEntityToRoomProjectionModel(Projection entity)
        {
            RoomProjectionModel model = new RoomProjectionModel()
            {
                Id = entity.ProjectionId,
                MovieTitle = entity.Movie?.Title,
                IsDeleted = entity.IsDeleted,
                Start = entity.Start,
                FreeBy = entity.FreeBy
            };
            return model;
        }
        public Room MapModelToEntity(RoomModel model)
        {
            Room entity = new Room()
            {
                RoomId = model.RoomId,
                Name = model.Name,
                CleanTimeMins = model.CleanTimeMins,
                IsDeleted = model.IsDeleted,
            };
            return entity;
        }
    }
}
