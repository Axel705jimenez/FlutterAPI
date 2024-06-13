using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> MostrarCategorias()
        {
            return await _context.Categoria.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> AgregarCategoria(Categoria categoria)
        {
            categoria.estatus = 1;

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.idCategoria }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCategoria(int id, Categoria categoria)
        {
            if (id != categoria.idCategoria)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExiste(id))
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

        [HttpPut("{id}/CambiarEstatus")]
        public async Task<IActionResult> CambiarEstatusCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            categoria.estatus = 0;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("reactivar/{id}")]
        public async Task<IActionResult> ReactivarCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            categoria.estatus = 1; 

            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool CategoriaExiste(int id)
        {
            return _context.Categoria.Any(e => e.idCategoria == id);
        }
    }
}
