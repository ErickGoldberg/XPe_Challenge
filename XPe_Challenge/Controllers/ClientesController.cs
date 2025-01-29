using Microsoft.AspNetCore.Mvc;
using XPe_Challenge.Models;
using XPe_Challenge.Services;

namespace XPe_Challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/Clientes/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var total = await _clienteService.CountAsync();
            return Ok(total);
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        // GET: api/Clientes/findByName?nome=joao
        [HttpGet("findByName")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetByName([FromQuery] string nome)
        {
            var clientes = await _clienteService.GetByNameAsync(nome);
            return Ok(clientes);
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> Create([FromBody] Cliente cliente)
        {
            var novoCliente = await _clienteService.CreateAsync(cliente);
            // Retorna o objeto criado com sua rota de acesso
            return CreatedAtAction(nameof(GetById), new { id = novoCliente.Id }, novoCliente);
        }

        // PUT: api/Clientes/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Cliente cliente)
        {
            var atualizado = await _clienteService.UpdateAsync(id, cliente);
            if (!atualizado)
                return NotFound("Cliente não encontrado ou ID inconsistente.");

            return NoContent();
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removido = await _clienteService.DeleteAsync(id);
            if (!removido)
                return NotFound("Cliente não encontrado.");

            return NoContent();
        }
    }
}
