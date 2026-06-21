namespace MyApiRest.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IWeatherServices _weatherService;

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly HttpClient _httpClient;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger
        , IWeatherServices weatherService
        , HttpClient httpClient)
    {
        _logger = logger;
        _weatherService = weatherService;
        _httpClient = httpClient;
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

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CoordenatesInsertDto coordenates)
    {     
        var result = await _weatherService.GetWeatherAsync(coordenates);
        return Ok(result);
    }
}
