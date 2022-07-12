using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace container_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private HttpClient client = new HttpClient();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
    {
        // BaseAddress environment variable is configured in launchSettings.json
        client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("API_BASE_ADDR"));
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var route = $"{Environment.GetEnvironmentVariable("API_BASE_ADDR")}/weatherforecast";
        var response = await client.GetAsync(route);
        var rawResponse = await response.Content.ReadAsStringAsync();

        if ((int)response.StatusCode != StatusCodes.Status200OK)
        {
            return BadRequest(rawResponse);
        }

        return Ok(JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(rawResponse));
    }
}
