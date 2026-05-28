using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundBitesAPI.Models;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace SoundBitesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listarusuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ListarUsuario()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios); //200
        }

        [HttpPost("guardarusuario")]
        public async Task<ActionResult<Usuario>> GuardarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, usuario);
        }

        [HttpPut("actualizarusuario/{id}")]
        public async Task<ActionResult> ActualizarUsuario(int id, Usuario usuario)
        {
            var usuarioActualizado = await _context.Usuarios.FindAsync(id);

            if (usuarioActualizado == null)
            {
                return NotFound(); //404
            }
            usuarioActualizado.Nombre = usuario.Nombre;
            usuarioActualizado.Correo = usuario.Correo;
            usuarioActualizado.Contrasena = usuario.Contrasena;
            usuarioActualizado.Rol = usuario.Rol;

            await _context.SaveChangesAsync();

            return Ok(usuarioActualizado);

        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == request.Correo && u.Contrasena == request.Contrasena);

            if (usuario == null)
            {
                return Unauthorized(); // 401
            }

            return Ok(usuario);
        }
    }
    public class LoginRequest
    {
        public required string Correo { get; set; }
        public required string Contrasena { get; set; }
    }

}
