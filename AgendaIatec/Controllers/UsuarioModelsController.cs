#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaIatec.Context;
using AgendaIatec.Models;
using AgendaIatec.Helpers;
using AgendaIatec.DTO;

namespace AgendaIatec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioModelsController : ControllerBase
    {
        private readonly Contexto _context;

        public UsuarioModelsController(Contexto context)
        {
            _context = context;
        }

        // GET: api/UsuarioModels
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> GetUsuarioModels()
        {
            var lista = await _context.UsuarioModels.Include(b => b.ParticipantesModel).ToListAsync();
            return lista;
        }

        // GET: api/UsuarioModels/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuarioModel(int id)
        {
            var usuarioModel = await _context.UsuarioModels.FindAsync(id);

            if (usuarioModel == null)
            {
                return NotFound();
            }
            var usuarioDTO = new UsuarioDTO(usuarioModel.Id, usuarioModel.Nome, usuarioModel.Email, usuarioModel.DataNascimento.ToShortDateString(), usuarioModel.Genero.ToString());
            return usuarioDTO;
        }

        // PUT: api/UsuarioModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioModel(int id, UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioModelExists(id))
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

        // POST: api/UsuarioModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> PostUsuarioModel(UsuarioModel usuarioModel)
        {
            _context.UsuarioModels.Add(usuarioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioModel", new { id = usuarioModel.Id }, usuarioModel);
        }

        // DELETE: api/UsuarioModels/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioModel(int id)
        {
            var usuarioModel = await _context.UsuarioModels.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            _context.UsuarioModels.Remove(usuarioModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioModelExists(int id)
        {
            return _context.UsuarioModels.Any(e => e.Id == id);
        }
    }
}
