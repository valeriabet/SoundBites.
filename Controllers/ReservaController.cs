using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundBitesAPI.Models;

namespace SoundBitesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listarreservas")]
        public async Task<ActionResult<IEnumerable<Reserva>>> ListarReservas()
        {
            var reservas = await _context.Reservas.ToListAsync();
            return Ok(reservas);
        }

        [HttpPost("guardarreserva")]
        public async Task<ActionResult<Reserva>> GuardarReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, reserva);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Reserva>> BuscarPorId(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }
    }
}