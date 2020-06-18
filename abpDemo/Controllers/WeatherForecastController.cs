using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp.Http.Client.DynamicProxying;

namespace abpDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IFackService _fackService;

        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(IUser user, ILogger<WeatherForecastController> logger, IFackService fackService)
        {
            _user = user;
            _logger = logger;
            _fackService = fackService;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var interceptorType = typeof(DynamicHttpProxyInterceptor<>).MakeGenericType(typeof(IUser));
            _fackService.SayHello();
            var user = await _user.GetUser();
            var rng = new Random();
            Console.WriteLine("你好啊");
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
