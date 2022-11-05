using Api_agencia.Data;
using Api_agencia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;


namespace Api_agencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public ClienteController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Cursos - LISTA TODOS OS CURSOS
        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes;
        }

        // GET: api/Cursos/id - LISTA CURSO POR ID
        [HttpGet("{id}")]
        public IActionResult GetClientePorId(long id)
        {
            Cliente cliente = _context.Clientes.SingleOrDefault(modelo => modelo.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return new ObjectResult(cliente);
        }

        // CRIA UM NOVO CURSO
        [HttpPost]
        public IActionResult CriarCliente(Cliente item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _context.Clientes.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }

        // ATUALIZA UM CURSO EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(long id, Cliente item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return new NoContentResult();
        }

        // APAGA UM CURSO POR ID
        [HttpDelete("{id}")]
        public IActionResult DeletaCliente(long id)
        {
            var cliente = _context.Clientes.SingleOrDefault(m => m.Id == id);
            if (cliente == null)
            {
                return BadRequest();
            }
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return Ok(cliente);
        }
    }
}
