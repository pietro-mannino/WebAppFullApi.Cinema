using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAppFullApi.Cinema.Data;
using WepAppFullApi.Cinema.Models;

namespace WepAppFullApi.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly CinemaDbContext _ctx;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieController> _logger;
        public MovieController(CinemaDbContext ctx, Mapper mapper, ILogger<MovieController> logger)
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
                return Ok(_ctx.Movies
                    .Include(m => m.Technologies)
                    .Include(m => m.AgeLimit)
                    .ToList()
                    .ConvertAll(_mapper.MapEntityToModel));
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
           Movie? entity = _ctx.Movies
                .Include(m => m.Technologies)
                .Include(m => m.AgeLimit)
                .Include(m => m.Projections).ThenInclude(p => p.Room)
                .SingleOrDefault(m => m.MovieId == id);
            if (entity == null)
                return NotFound("Film non trovato");
            return Ok(_mapper.MapEntityToModel(entity));
                
        }

        [HttpPost]
        public IActionResult Post(MovieModel model)
        {
            Movie entity = _mapper.MapModelToEntity(model);
            entity.MovieId = 0;
            entity.IsDeleted = false;
            if (model.Technologies != null)
            {
                List<int> techids = model.Technologies.Select(t => t.Id).ToList();
                entity.Technologies = _ctx.Technologies
                    .Join(techids, t => t.TechnologyId, ts => ts, (t, ts) => t).ToList();
            }
            _ctx.Movies.Add(entity);
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }

        [HttpPut]
        public IActionResult Put(MovieModel model)
        {
            Movie movie = _mapper.MapModelToEntity(model);
            var toedit = _ctx.Movies.SingleOrDefault(m => m.MovieId == movie.MovieId);
            if (toedit == null) 
                return BadRequest();
            toedit.Title = movie.Title;
            toedit.DurationMins = movie.DurationMins;
            toedit.AgeLimitId = movie.AgeLimitId;
            toedit.ImdbId = movie.ImdbId;
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
            Movie? entity = _ctx.Movies.Include(m => m.Projections).SingleOrDefault(m => m.MovieId == id);
            if (entity == null)
                return BadRequest("Film non trovato");
            entity.IsDeleted = action;
            entity.Projections?.ForEach(p => p.IsDeleted = action);
            return _ctx.SaveChanges() > 0 ?
                Ok() : 
                BadRequest();
        }
    }
}
