using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> MostrarPedido()
        {
            return await _context.Pedido.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> AgregarPedido(Pedido nuevoPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pedido.Add(nuevoPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedido), new { id = nuevoPedido.idPedido }, nuevoPedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPedido(int id, Pedido pedidoActualizado)
        {
            if (id != pedidoActualizado.idPedido)
            {
                return BadRequest();
            }

            _context.Entry(pedidoActualizado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExiste(id))
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
        public async Task<IActionResult> CambiarEstatusPedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedido.estatus = 0; 

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExiste(id))
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
        public async Task<IActionResult> ReactivarPedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedido.estatus = 1;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExiste(id))
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

        private bool PedidoExiste(int id)
        {
            return _context.Pedido.Any(e => e.idPedido == id);
        }
    }
}
