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

        private readonly ILogger<ClienteController> _logger;

        public List<Cliente> cadastros { get; set; }
        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
            cadastros = Enumerable.Range(1, 5).Select(index => new Cliente
            {
                DataNascimento = DateTime.Now.AddDays(-Random.Shared.Next(6000, 20000)),
                Cpf = Random.Shared.Next(000000000, 999999999),
                Nome = nomes[Random.Shared.Next(nomes.Length)]
            })
                .ToList();
        }

        [HttpGet]
        public List<Cliente> Consult(int index)
        {
            return cadastros;
        }

        [HttpPost]
        public Cliente Insert(Cliente cadastro)
        {
            cadastros.Add(cadastro);
            return cadastro;
        }

        [HttpPut]
        public Cliente Atualizar(int index, Cliente cadastro)
        {
            cadastros[index] = cadastro;
            return cadastros[index];
        }

        [HttpDelete]
        public List<Cliente> Deletar(int index)
        {
            cadastros.RemoveAt(index);
            return cadastros;
        }
    }
}
