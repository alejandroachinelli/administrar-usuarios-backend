using backend.Models;
using backend.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("ObtenerUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerUsuarios(
            [FromQuery] string nombre = null,
            [FromQuery] string email = null,
            [FromQuery] int? edad = null,
            [FromQuery] int pageSize = 10,
            [FromQuery] int page = 1
        )
        {
            var query = _context.Usuario.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(u => u.Nombre.Contains(nombre));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(u => u.Correo.Contains(email));
            }

            if (edad.HasValue)
            {
                query = query.Where(u => u.Edad == edad.Value);
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }

        [HttpPost("AgregarUsuarios")]
        public async Task<ActionResult<Usuario>> CrearUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerUsuarios), new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut("ActualizarUsuario/{id}")]
        public async Task<IActionResult> ActualizarUsuario(Guid id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        [HttpDelete("EliminarUsuario/{id}")]
        public async Task<IActionResult> EliminarUsuario(Guid id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(Guid id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }
    }
}
