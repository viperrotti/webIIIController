using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using testeAPI.Core.Interface;
using testeAPI.Core.Models;

namespace testeAPI.Filters
{
    public class VerificaCpfActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;
        public VerificaCpfActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cliente cliente = (Cliente)context.ActionArguments["cliente"];
            var clientePesquisa = _clienteService.GetClientePorCPF(cliente.Cpf);

            if (clientePesquisa != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }


    }
}
