using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace testeAPI.Filters
{
    public class LogResourceFilter : IResourceFilter
    {
        Stopwatch stopwatch = new();
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("Filtro de Resource LogResourceFilter (APÓS) OnResourceExecuted");
            stopwatch.Stop();
            Console.WriteLine($"Ação executada em {stopwatch.ElapsedMilliseconds} ms");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.Keys.Contains("Code"))
            {
                context.HttpContext.Request.Headers.Add("Code", Guid.NewGuid().ToString());
            }
            stopwatch.Start();
            Console.WriteLine("Filtro de Resource LogResourceFilter (ANTES) OnResourceExecuting");
        }
    }
}
