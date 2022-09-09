using testeAPI.Core.Models;

namespace testeAPI.Core.Interface
{
    public interface IClienteService
    {
        List<Cliente> GetClientes();

        Cliente GetClientePorCPF(string cpf);

        Cliente GetClientePorId(long id);

        bool InsertCliente(Cliente cliente);

        bool DeleteCliente(long id);

        bool UpdateCliente(long id, Cliente cliente);
    }
}
