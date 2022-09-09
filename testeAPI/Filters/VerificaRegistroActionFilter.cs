using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using testeAPI.Core.Interface;

namespace testeAPI.Filters
{
    public class VerificaRegistroActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;
        public VerificaRegistroActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long idCliente = (long)context.ActionArguments["id"];

            if (_clienteService.GetClientePorId(idCliente) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
