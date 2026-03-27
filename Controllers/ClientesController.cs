using Microsoft.AspNetCore.Mvc;
using MiniCRM.Api.Data;
using MiniCRM.Api.Models;

namespace MiniCRM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            var data = new ClienteData();
            var clientes = data.ObtenerClientes();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetPorId(int id)
        {
            var data = new ClienteData();
            var cliente = data.ObtenerClientePorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }



        [HttpPost]


        public ActionResult Post([FromBody] Cliente cliente)
        {
            var data = new ClienteData();
            data.InsertarCliente(cliente);

            return Ok(cliente);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest(new { mensaje = "El id de la ruta no coincide con el del cliente" });
            }

            var data = new ClienteData();
            var clienteExistente = data.ObtenerClientePorId(id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            data.ActualizarCliente(cliente);

            return Ok(cliente);
        }
    }
}