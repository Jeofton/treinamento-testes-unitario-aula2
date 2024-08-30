using GestaoEstoque.Models;
using GestaoEstoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
        {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
            {
            _clienteService = clienteService;
            }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
            {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
            }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
            {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if(cliente == null)
                return NotFound();
            return Ok(cliente);
            }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
            {
            var createdCliente = await _clienteService.CreateClienteAsync(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = createdCliente.Id }, createdCliente);
            }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
            {
            if(id != cliente.Id)
                return BadRequest();

            await _clienteService.UpdateClienteAsync(cliente);
            return NoContent();
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
            {
            var result = await _clienteService.DeleteClienteAsync(id);
            if(!result)
                return NotFound();

            return NoContent();
            }
        }
    }
