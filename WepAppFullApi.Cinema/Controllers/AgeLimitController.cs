using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepAppFullApi.Cinema.Data;
using WepAppFullApi.Cinema.Models;

namespace WepAppFullApi.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeLimitController : ControllerBase
    {
        private readonly CinemaDbContext _ctx;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieController> _logger;
        public AgeLimitController(CinemaDbContext ctx, Mapper mapper, ILogger<MovieController> logger)
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ctx.AgeLimits
                .Where(e => e.IsDeleted == false)
                .ToList()
                .ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("Complete")]
        public IActionResult GetAllComplete()
        {
            return Ok(_ctx.AgeLimits
                .ToList()
                .ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            AgeLimit? entity = _ctx.AgeLimits
                .SingleOrDefault(e => e.AgeLimitId == id);
            if (entity == null)
                return NotFound("Limite di età non trovata");
            return Ok(_mapper.MapEntityToModel(entity));
        }

        [HttpPost]
        public IActionResult Post(ItemModel model)
        {
            AgeLimit entity = _mapper.MapModelToAgeLimitEntity(model);
            entity.AgeLimitId = 0;
            entity.IsDeleted = false;
            _ctx.AgeLimits.Add(entity);
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }

        [HttpPut]
        public IActionResult Put(ItemModel model)
        {
            AgeLimit entity = _mapper.MapModelToAgeLimitEntity(model);
            var toedit = _ctx.AgeLimits.SingleOrDefault(e => e.AgeLimitId == entity.AgeLimitId);
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
            AgeLimit? entity = _ctx.AgeLimits
                .SingleOrDefault(m => m.AgeLimitId == id);
            if (entity == null)
                return BadRequest("Tecnologia non trovata");
            entity.IsDeleted = action;
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }
    }
}
