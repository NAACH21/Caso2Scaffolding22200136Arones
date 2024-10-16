using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Caso2Scaffolding22200136Arones.DOMAIN.Core.Entities;
using Caso2Scaffolding22200136Arones.DOMAIN.Data;

namespace Caso2Scaffolding22200136Arones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly Parcial20240222200136Context _context;

        public JobController(Parcial20240222200136Context context)
        {
            _context = context;
        }

        // GET: api/Job
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOffer>>> GetJobOffer()
        {
            return await _context.JobOffer.ToListAsync();
        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobOffer>> GetJobOffer(int id)
        {
            var jobOffer = await _context.JobOffer.FindAsync(id);

            if (jobOffer == null)
            {
                return NotFound();
            }

            return jobOffer;
        }

        // PUT: api/Job/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobOffer(int id, JobOffer jobOffer)
        {
            if (id != jobOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobOfferExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Job
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobOffer>> PostJobOffer(JobOffer jobOffer)
        {
            _context.JobOffer.Add(jobOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobOffer", new { id = jobOffer.Id }, jobOffer);
        }

        // DELETE: api/Job/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobOffer(int id)
        {
            var jobOffer = await _context.JobOffer.FindAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            _context.JobOffer.Remove(jobOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobOfferExists(int id)
        {
            return _context.JobOffer.Any(e => e.Id == id);
        }
    }
}
