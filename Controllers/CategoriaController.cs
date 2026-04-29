using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundBitesAPI.Models;

namespace SoundBitesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar categorias")]
        public async Task<ActionResult<IEnumerable<Categoria>>> ListarCategorias()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return Ok(categorias); //200
        }

        [HttpPost("Guardar categoria")]
        public async Task<ActionResult<Genero>> GuardarCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, categoria);
        }
    }
}
