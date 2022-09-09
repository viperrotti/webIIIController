using testeAPI.Core.Interface;
using testeAPI.Core.Models;

namespace testeAPI.Core.Services
{
    public class ClienteService : IClienteService
    {
        public IRepositoryCliente _repositoryCliente;
        public ClienteService(IRepositoryCliente repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public List<Cliente> GetClientes()
        {
            return _repositoryCliente.GetClientes();
        }

        public Cliente GetClientePorCPF(string cpf)
        {
            return _repositoryCliente.GetClientePorCPF(cpf);
        }

        public Cliente GetClientePorId(long id)
        {
            return _repositoryCliente.GetClientePorId(id);
        }

        public bool InsertCliente(Cliente cliente)
        {
            return _repositoryCliente.InsertCliente(cliente);
        }

        public bool DeleteCliente(long id)
        {
            return _repositoryCliente.DeleteCliente(id);
        }

        public bool UpdateCliente(long id, Cliente cliente)
        {
            return _repositoryCliente.UpdateCliente(id, cliente);
        }



    }
}
