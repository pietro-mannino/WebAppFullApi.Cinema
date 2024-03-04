using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAppFullApi.Cinema.Data;
using WepAppFullApi.Cinema.Models;

namespace WepAppFullApi.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CinemaDbContext _ctx;
        private readonly Mapper _mapper;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(CinemaDbContext ctx, Mapper mapper, ILogger<EmployeeController> logger)
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_ctx.Employees
                .Where(e => e.IsDeleted == false)
                .ToList()
                .ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("Complete")]
        public IActionResult GetAllComplete()
        {
            return Ok(_ctx.Employees
                .ToList()
                .ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            Employee? entity = _ctx.Employees
                .Include(a => a.ProjectionActivities
                .Where(p => p.Projection.FreeBy > DateTime.Now)).ThenInclude(p => p.Projection) //VERIFICARE!!!!
                .SingleOrDefault(e => e.EmployeeId == id);
            if (entity == null)
                return NotFound("Film non trovato");
            //entity.ProjectionActivities = _ctx.Activities.Where(x => x.EmployeeId == id && x.Projection.FreeBy > DateTime.Now).ToList();
            return Ok(_mapper.MapEntityToModel(entity));
        }

        [HttpGet]
        [Route("Full/{id}")]
        public IActionResult GetByIdFull(int id)
        {
            Employee? entity = _ctx.Employees
                .Include(a => a.ProjectionActivities)
                .ToList()
                .SingleOrDefault(e => e.EmployeeId == id);
            if (entity == null)
                return NotFound("Film non trovato");
            return Ok(entity.ProjectionActivities);
        }

        [HttpPost]
        public IActionResult Post(ItemModel model)
        {
            Employee entity = _mapper.MapModelToEmployeeEntity(model);
            entity.EmployeeId = 0;
            entity.IsDeleted = false;
            _ctx.Employees.Add(entity);
            return _ctx.SaveChanges() > 0 ?
                Ok() :
                BadRequest();
        }

        [HttpPut]
        public IActionResult Put(ItemModel model)
        {
            Employee entity = _mapper.MapModelToEmployeeEntity(model);
            var toedit = _ctx.Employees.SingleOrDefault(e => e.EmployeeId == entity.EmployeeId);
            toedit.Name = entity.Name;
            toedit.Surname = entity.Surname;
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
            Employee? entity = _ctx.Employees
                .SingleOrDefault(m => m.EmployeeId == id);
            if (entity == null)
                return BadRequest("Film non trovato");
            entity.IsDeleted = action;
            entity.ProjectionActivities?.ForEach(p => p.IsDeleted = action);

            return _ctx.SaveChanges() > 0 ?  
                Ok() : 
                BadRequest();
        }
    }
}
