using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAppFullApi.Cinema.Data;
using WepAppFullApi.Cinema.Models;

namespace WepAppFullApi.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionController : ControllerBase
    {
        private readonly CinemaDbContext _ctx;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieController> _logger;
        public ProjectionController(CinemaDbContext ctx, Mapper mapper, ILogger<MovieController> logger)
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ctx.Projections
                    .Include(x => x.Room)
                    .Include(x => x.Movie)
                    .ToList()
                    .ConvertAll(_mapper.MapEntityToFullModel));
            }
            catch (Exception ex)
            {
                _logger.LogError("Errore nel server");
                return StatusCode(StatusCodes.Status500InternalServerError, "si è rotto qualcosa");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            Projection? entity = _ctx.Projections
                 .Include(x => x.Room)
                 .Include(x => x.Movie)
                 .Include(x => x.Activities).ThenInclude(x => x.Employee)
                 .Include(x => x.Activities).ThenInclude(x => x.ActivityRole)
                 .ToList()
                 .SingleOrDefault(m => m.ProjectionId == id);
            if (entity == null)
                return NotFound("Proiezione non trovata");
            return Ok(_mapper.MapEntityToFullModel(entity));
        }

        [HttpPost]
        public IActionResult Post(ProjectionModel model)
        {
            Projection entity = _mapper.MapModelToEntity(model);
            entity.ProjectionId = 0;
            entity.IsDeleted = false;
            entity.FreeBy = entity.Start.AddMinutes(
                _ctx.Movies.SingleOrDefault(m => m.MovieId == entity.MovieId).DurationMins +
                _ctx.Rooms.SingleOrDefault(r => r.RoomId == entity.RoomId).CleanTimeMins
                );
            _ctx.Projections.Add(entity);
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }

        [HttpPut]
        public IActionResult Put(ProjectionModel model)
        {
            Projection entity = _mapper.MapModelToEntity(model);
            var toedit = _ctx.Projections.SingleOrDefault(p => p.ProjectionId == entity.ProjectionId);
            toedit.MovieId = toedit.MovieId;
            toedit.RoomId = toedit.RoomId;
            toedit.Start = toedit.Start;
            toedit.FreeBy = toedit.FreeBy;
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }

        [HttpDelete]
        [Route("Disable/{id}")]
        public IActionResult Disable(int id)
        {
            return EnableOrDisable(id, true);
        }

        [HttpDelete]
        [Route("Enable/{id}")]
        public IActionResult Reactivate(int id)
        {
            return EnableOrDisable(id, false);
        }


        private IActionResult EnableOrDisable(int id, bool action)
        {
            Projection? entity = _ctx.Projections
                .Include(a => a.Activities)
                .SingleOrDefault(p => p.MovieId == id);
            if (entity == null)
                return BadRequest("Film non trovato");
            entity.IsDeleted = action;
            entity.Activities?.ForEach(a => a.IsDeleted = action);
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }
    }
}
