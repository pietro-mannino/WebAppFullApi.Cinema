using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAppFullApi.Cinema.Data;
using WepAppFullApi.Cinema.Models;

namespace WepAppFullApi.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly CinemaDbContext _ctx;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieController> _logger;
        public RoomController(CinemaDbContext ctx, Mapper mapper, ILogger<MovieController> logger)
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ctx.Rooms
                .Include(t => t.Technologies)
                .Include(p => p.Projections)
                .Where(e => e.IsDeleted == false)
                .ToList()
                .ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("Complete")]
        public IActionResult GetAllComplete()
        {
            return Ok(_ctx.Rooms
                .ToList()
                .ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            Room? entity = _ctx.Rooms
                .Include(p => p.Projections)
                .Include(t => t.Technologies)
                .SingleOrDefault(e => e.RoomId == id);
            if (entity == null)
                return NotFound("Tecnologia non trovata");
            return Ok(_mapper.MapEntityToModel(entity));
        }

        [HttpPost]
        public IActionResult Post(RoomModel model)
        {
            Room entity = _mapper.MapModelToEntity(model);
            entity.RoomId = 0;
            entity.IsDeleted = false;
            if (model.Technologies != null)
            {
                List<int> techids = model.Technologies.Select(t => t.Id).ToList();
                entity.Technologies = _ctx.Technologies
                    .Join(techids, t => t.TechnologyId, ts => ts, (t, ts) => t).ToList();
            }
            _ctx.Rooms.Add(entity);
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }

        [HttpPut]
        public IActionResult Put(RoomModel model)
        {
            Room entity = _mapper.MapModelToEntity(model);
            var toedit = _ctx.Rooms.SingleOrDefault(r => r.RoomId == entity.RoomId);
            toedit.Name = entity.Name;
            toedit.CleanTimeMins = entity.CleanTimeMins;
            toedit.IsDeleted = entity.IsDeleted;

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
            Room? entity = _ctx.Rooms
                .SingleOrDefault(r => r.RoomId == id);
            if (entity == null)
                return BadRequest("Stanza non trovata");
            entity.IsDeleted = action;
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }
    }
}
