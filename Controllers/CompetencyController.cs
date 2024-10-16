using Caso2Scaffolding22200136Arones.DOMAIN.Core.Entities;
using Caso2Scaffolding22200136Arones.DOMAIN.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caso2Scaffolding22200136Arones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetencyController : ControllerBase
    {
        private readonly ICompetencyRepository _competencyRepository;

        public CompetencyController(ICompetencyRepository competencyRepository)
        {
            _competencyRepository = competencyRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCompetency()
        {
            var competency = await _competencyRepository.GetAllCompetency();
            return Ok(competency);
        }

        [HttpPost]

        public async Task<IActionResult> Create(Competency competency)
        {
            int competencyId = await _competencyRepository.Insert(competency);
            return Ok(competency);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, Competency competency)
        {
            if (id != competency.Id)
            {
                return BadRequest();
            }
            var result = await _competencyRepository.Update(competency);
            if (!result) return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _competencyRepository.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }
    }
}
