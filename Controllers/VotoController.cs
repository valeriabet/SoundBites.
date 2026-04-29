using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundBitesAPI.Models;

namespace SoundBitesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VotoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar votos")]
        public async Task<ActionResult<IEnumerable<Voto>>> ListarVotos()
        {
            var votos = await _context.Votos.ToListAsync();
            return Ok(votos); //200
        }

        [HttpPost("Guardar voto")]
        public async Task<ActionResult<Genero>> GuardarVoto(Voto voto)
        {
            _context.Votos.Add(voto);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, voto);
        }
    }
}
