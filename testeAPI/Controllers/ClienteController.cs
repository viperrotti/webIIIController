using Microsoft.AspNetCore.Mvc;

namespace testeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private static readonly string[] nomes = new[]
        {
        "Renato", "Marcela", "Mariana", "Fernanda", "Rodrigo", "Ricardo", "João Carlos", "Viviane", "Victor"
    };
        private static readonly string[] cpfs = new[]
        {
        "32699877433", "65887799633", "57899968544", "22588465899", "33477851298", "85744695322", "54899632577", "55123659988", "32899564722"
    };

        private readonly ILogger<ClienteController> _logger;

        public List<Cliente> cadastros { get; set; }
        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
            cadastros = Enumerable.Range(1, 5).Select(index => new Cliente
            {
                DataNascimento = DateTime.Now.AddDays(-Random.Shared.Next(6000, 20000)),
                Cpf = cpfs[Random.Shared.Next(cpfs.Length)],
                Nome = nomes[Random.Shared.Next(nomes.Length)]
            })
                .ToList();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> Consultar()
        {
            return Ok(cadastros);
        }

        [HttpGet("/cadastro/{index}/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> Consultar2(int index)
        {
            if (index > cadastros.Count)
            {
                return NotFound();
            }
            return Ok(cadastros[index]);
        }


        [HttpPost("/cadastro/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult <Cliente> Inserir([FromBody]Cliente cadastro)
        {
            cadastros.Add(cadastro);
            return StatusCode(201, cadastro);
        }

        [HttpPut("/cadastro/{index}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(int index, Cliente cadastro)
        {
            if(index >= cadastros.Count || index < 0)
            {
                return NotFound();
            }
            cadastros[index] = cadastro;
            return Ok(cadastros[index]);
        }


        [HttpDelete("/cadastro/{index}/deletar")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Deletar(int index)
        {
            if(index >= cadastros.Count || index < 0)
            {
                return NotFound();
            }
            cadastros.RemoveAt(index);
            return NoContent();
        }
    }
}
