using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace abpDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUser _user;
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(IUser user, ILogger<WeatherForecastController> logger)
        {
            _user = user;
            _logger = logger;
        }


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var user =
               _user.GetUser();
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
