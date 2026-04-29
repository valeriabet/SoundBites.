using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundBitesAPI.Models;

namespace SoundBitesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlatoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar platos")]
        public async Task<ActionResult<IEnumerable<Plato>>> ListarPlatos()
        {
            var platos = await _context.Platos.ToListAsync();
            return Ok(platos); //200
        }

        [HttpPost("guardar plato")]
        public async Task<ActionResult<Genero>> GuardarPlato(Plato plato)
        {
            _context.Platos.Add(plato);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, plato);
        }
    }
}
