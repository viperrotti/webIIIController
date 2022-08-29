using Microsoft.AspNetCore.Mvc;

namespace testeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public List<WeatherForecast> tempos { get; set; }
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            tempos = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
                .ToList();
        }

        [HttpGet]
        public List<WeatherForecast> Consult (int index)
        {
            return tempos;
        }

        [HttpPost]
        public WeatherForecast Insert(WeatherForecast tempo)
        {
            tempos.Add(tempo);
            return tempo;
        }

        [HttpPut]
        public WeatherForecast Atualizar(int index, WeatherForecast tempo)
        {
            tempos[index] = tempo;
            return tempos[index];
        }

        [HttpDelete]
        public List<WeatherForecast> Deletar(int index)
        {
            tempos.RemoveAt(index);
            return tempos;
        }
    }
}