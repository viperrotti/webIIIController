using Microsoft.AspNetCore.Mvc;
using testeAPI.Repository;

namespace testeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        public List<Cliente> ClientesList { get; set; }

        public RepositoryCliente _repositoryCliente;

        public ClienteController(IConfiguration configuration)
        {
            ClientesList = new List<Cliente>();
            _repositoryCliente = new RepositoryCliente(configuration);
        }

        [HttpGet("/Cliente/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cliente> GetClientePorCPF(string cpf)
        {
            var cliente = _repositoryCliente.GetClientePorCPF(cpf);
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
            return Ok(_repositoryCliente.GetClientes());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cliente> PostCliente(Cliente cliente)
        {
            if (!_repositoryCliente.InsertCliente(cliente))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(PostCliente), cliente);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateProduto(long id, Cliente cliente)
        {
            if (!_repositoryCliente.UpdateCliente(id, cliente))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> DeleteCliente(long id)
        {
            if (!_repositoryCliente.DeleteCliente(id))
            {
                return NotFound();
            }
            return NoContent();
        }
         
    }
}
