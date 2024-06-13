using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {
        private readonly DataContext _context;

        public DetallePedidoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> MostrarDetallePedido()
        {
            return await _context.DetallePedido.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetallePedido(int id)
        {
            var detallePedido = await _context.DetallePedido.FindAsync(id);

            if (detallePedido == null)
            {
                return NotFound();
            }

            return detallePedido;
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedido>> AgregarDetallePedido([FromBody] DetallePedido detallePedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                detallePedido.estatus = 1;

                _context.DetallePedido.Add(detallePedido);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetDetallePedido), new { id = detallePedido.idDetallePedido }, detallePedido);
            }
            catch (Exception ex)
            {
                // Loguear el error
                return StatusCode(500, "Failed to add detail of order. Error: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDetallePedido(int id, [FromBody] DetallePedido detallePedido)
        {
            if (id != detallePedido.idDetallePedido)
            {
                return BadRequest();
            }

            _context.Entry(detallePedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoExists(id))
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
        public async Task<IActionResult> CambiarEstatusDetallePedido(int id)
        {
            var detallePedido = await _context.DetallePedido.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            detallePedido.estatus = 0;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoExists(id))
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

        [HttpPut("{id}/Reactivar")]
        public async Task<IActionResult> ReactivarDetallePedido(int id)
        {
            var detallePedido = await _context.DetallePedido.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            detallePedido.estatus = 1;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoExists(id))
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

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallePedido.Any(e => e.idDetallePedido == id);
        }
    }
}
