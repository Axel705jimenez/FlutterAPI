using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> MostrarCliente()
        {
            return await _context.Cliente.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> AgregarCliente(Cliente nuevoCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            nuevoCliente.estatus = nuevoCliente.estatus == 1 ? 1 : 0;

            _context.Cliente.Add(nuevoCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = nuevoCliente.idCliente }, nuevoCliente);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, Cliente clienteActualizado)
        {
            if (id != clienteActualizado.idCliente)
            {
                return BadRequest();
            }

            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            cliente.nombre = clienteActualizado.nombre;
            cliente.apellido = clienteActualizado.apellido;
            cliente.direccion = clienteActualizado.direccion;
            cliente.telefono = clienteActualizado.telefono;
            cliente.correo = clienteActualizado.correo;
            cliente.estatus = clienteActualizado.estatus == 1 ? 1 : 0;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExiste(id))
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
        public async Task<IActionResult> CambiarEstatusCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.estatus = 0;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("reactivar/{id}")]
        public async Task<IActionResult> ReactivarCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.estatus = 1; 

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExiste(int id)
        {
            return _context.Cliente.Any(e => e.idCliente == id);
        }
    }
}
