using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepAppFullApi.Cinema.Data;
using WepAppFullApi.Cinema.Models;

namespace WepAppFullApi.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityRoleController : ControllerBase
    {
        private readonly CinemaDbContext _ctx;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieController> _logger;
        public ActivityRoleController(CinemaDbContext ctx, Mapper mapper, ILogger<MovieController> logger)
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ctx.ActivityRoles
                .Where(e => e.IsDeleted == false)
                .ToList()
                .ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("Complete")]
        public IActionResult GetAllComplete()
        {
            return Ok(_ctx.ActivityRoles
                .ToList()
                .ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            ActivityRole? entity = _ctx.ActivityRoles
                .SingleOrDefault(e => e.ActivityRoleId == id);
            if (entity == null)
                return BadRequest("Ruolo non trovato");
            return Ok(_mapper.MapEntityToModel(entity));
        }

        [HttpPost]
        public IActionResult Post(ItemModel model)
        {
            ActivityRole entity = _mapper.MapModelToActivityRoleEntity(model);
            entity.ActivityRoleId = 0;
            entity.IsDeleted = false;
            _ctx.ActivityRoles.Add(entity);
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }

        [HttpPut]
        public IActionResult Put(ItemModel model)
        {
            ActivityRole entity = _mapper.MapModelToActivityRoleEntity(model);
            var toedit = _ctx.ActivityRoles.SingleOrDefault(a => a.ActivityRoleId == entity.ActivityRoleId);
            if (toedit == null)
                return BadRequest("Ruolo non trovato");
            toedit.Description = entity.Description;

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
            ActivityRole? entity = _ctx.ActivityRoles
                .SingleOrDefault(m => m.ActivityRoleId == id);
            if (entity == null)
                return BadRequest("Ruolo non trovato");
            entity.IsDeleted = action;
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }
    }
}
