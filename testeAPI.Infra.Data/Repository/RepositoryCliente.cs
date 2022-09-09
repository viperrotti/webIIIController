using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using testeAPI.Core.Interface;
using testeAPI.Core.Models;

namespace testeAPI.Infra.Data.Repository
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private readonly IConfiguration _configuration;

        public RepositoryCliente(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cliente> GetClientes()
        {
            var query = "SELECT * FROM Clientes";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<Cliente>(query).ToList();
        }

        public Cliente GetClientePorCPF(string cpf)
        {
            var query = "SELECT * FROM Clientes WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Cliente>(query, parameters);
        }

        public Cliente GetClientePorId(long id)
        {
            var query = "SELECT * FROM Clientes WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Cliente>(query, parameters);
        }


        public bool InsertCliente(Cliente cliente)
        {
            var query = "INSERT INTO Clientes VALUES (@cpf, @nome, @dataNascimento, @idade)";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cliente.Cpf);
            parameters.Add("nome", cliente.Nome);
            parameters.Add("dataNascimento", cliente.DataNascimento);
            parameters.Add("idade", cliente.Idade);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteCliente(long id)
        {
            var query = "DELETE FROM Clientes WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateCliente(long id, Cliente cliente)
        {
            var query = "UPDATE Clientes SET nome = @nome, cpf = @cpf, dataNascimento = @dataNascimento, idade = @idade WHERE id = @id";

            var parameters = new DynamicParameters(cliente);
            cliente.Id = id;

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }
    }
}
