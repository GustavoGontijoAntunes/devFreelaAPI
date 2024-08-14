using DevFreela.Application.Models;
using DevFreela.Application.Services;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        private readonly ISkillService _skillService;

        public SkillsController(DevFreelaDbContext context, ISkillService skillService) 
        {
            _context = context;
            _skillService = skillService;
        }

        // GET api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _skillService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _skillService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // POST api/skills
        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model) 
        {
            var result = _skillService.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }
    }
}