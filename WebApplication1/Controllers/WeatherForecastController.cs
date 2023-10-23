using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApplication1.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }






    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        public TestController()
        {

        }
        [HttpGet(Name = "aaa")]
        public string Get()
        {
            return JsonSerializer.Serialize(new { Name = "ddd", Age = 19 });
        }


        [HttpGet(Name = "Getbbb")]
        public string Gbbb()
        {//text/paint
            return "ddd";// new { Name = "ddd", Age = 19 };
        }


        [HttpGet(Name = "Getaaa")]
        public object Gaaa()
        {//application/json
            return new { Name = "ddd", Age = 19 };
        }


    }











}