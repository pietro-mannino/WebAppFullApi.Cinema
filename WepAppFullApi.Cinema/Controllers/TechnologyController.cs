using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WepAppFullApi.Cinema.Data;
using WepAppFullApi.Cinema.Models;

namespace WepAppFullApi.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly CinemaDbContext _ctx;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieController> _logger;
        public TechnologyController(CinemaDbContext ctx, Mapper mapper, ILogger<MovieController> logger)
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ctx.Technologies
                .Where(e => e.IsDeleted == false)
                .ToList()
                .ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("Complete")]
        public IActionResult GetAllComplete()
        {
            return Ok(_ctx.Technologies
                .ToList()
                .ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _ctx.Technologies
                .SingleOrDefault(e => e.TechnologyId == id);
            if (entity == null)
                return BadRequest("Tecnologia non trovata");
            return Ok(_mapper.MapEntityToModel(entity));
        }

        [HttpPost]
        public IActionResult Post(ItemModel model)
        {
            var entity = _mapper.MapModelToTechnologyEntity(model);
            entity.TechnologyId = 0;
            entity.IsDeleted = false;
            _ctx.Technologies.Add(entity);
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }

        [HttpPut]
        public IActionResult Put(ItemModel model)
        {
            var entity = _mapper.MapModelToTechnologyEntity(model);
            var toedit = _ctx.Technologies.SingleOrDefault(e => e.TechnologyId == entity.TechnologyId);
            if (toedit == null)
                return BadRequest("Tecnologia non trovata");
            toedit.Name = entity.Name;
            toedit.TechnologyType = entity.TechnologyType;

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
            var entity = _ctx.Technologies
                .SingleOrDefault(m => m.TechnologyId == id);
            if (entity == null)
                return BadRequest("Tecnologia non trovata");
            entity.IsDeleted = action;
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }
    }
}
