using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using testeAPI.Core.Interface;
using testeAPI.Core.Models;
using testeAPI.Filters;

namespace testeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(LogResourceFilter))]

    public class ClienteController : ControllerBase
    {
        public IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("/Cliente/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cliente> GetClientePorCPF(string cpf)
        {
            var cliente = _clienteService.GetClientePorCPF(cpf);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpGet("/Cliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> GetClientes()
        {
            return Ok(_clienteService.GetClientes());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [TypeFilter(typeof(LogActionFilter))]
        [ServiceFilter(typeof(VerificaCpfActionFilter))]
        public ActionResult<Cliente> PostCliente(Cliente cliente)
        {
            if (!_clienteService.InsertCliente(cliente))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(PostCliente), cliente);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [TypeFilter(typeof(LogActionFilter))]
        [ServiceFilter(typeof(VerificaRegistroActionFilter))]

        public IActionResult UpdateCliente(long id, Cliente cliente)
        {
            if (!_clienteService.UpdateCliente(id, cliente))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> DeleteCliente(long id)
        {
            if (!_clienteService.DeleteCliente(id))
            {
                return NotFound();
            }
            return NoContent();
        }
         
    }
}
