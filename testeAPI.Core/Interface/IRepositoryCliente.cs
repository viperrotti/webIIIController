using testeAPI.Core.Models;

namespace testeAPI.Core.Interface
{
    public interface IRepositoryCliente
    {
        List<Cliente> GetClientes();

        Cliente GetClientePorCPF(string cpf);

        Cliente GetClientePorId(long Id);

        bool InsertCliente(Cliente cliente);

        bool DeleteCliente(long id);

        bool UpdateCliente(long id, Cliente cliente);




    }
}
