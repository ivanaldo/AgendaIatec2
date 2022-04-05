#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaIatec.Context;
using AgendaIatec.Models;
using AgendaIatec.Helpers;

namespace AgendaIatec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaModelsController : ControllerBase
    {
        private readonly Contexto _context;

        public AgendaModelsController(Contexto context)
        {
            _context = context;
        }

        // GET: api/AgendaModels
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendaModel>>> GetAgendaModels()
        {
            return await _context.AgendaModels.ToListAsync();
        }

        // GET: api/AgendaModels/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AgendaModel>> GetAgendaModel(int id)
        {
            var agendaModel = await _context.AgendaModels.FindAsync(id);

            if (agendaModel == null)
            {
                return NotFound();
            }

            return agendaModel;
        }

        // PUT: api/AgendaModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendaModel(int id, AgendaModel agendaModel)
        {
            if (id != agendaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(agendaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaModelExists(id))
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

        // POST: api/AgendaModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AgendaModel>> PostAgendaModel(AgendaModel agendaModel)
        {
            _context.AgendaModels.Add(agendaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgendaModel", new { id = agendaModel.Id }, agendaModel);
        }

        // DELETE: api/AgendaModels/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendaModel(int id)
        {
            var agendaModel = await _context.AgendaModels.FindAsync(id);
            if (agendaModel == null)
            {
                return NotFound();
            }

            _context.AgendaModels.Remove(agendaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgendaModelExists(int id)
        {
            return _context.AgendaModels.Any(e => e.Id == id);
        }
    }
}
