namespace WeatherForecast.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherServices _weatherService;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger
        , IWeatherServices weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpPost("city-coordinates")]
    public async Task<IActionResult> GetCityCoordinatesAsync([FromBody] CityRequestDto cityRequest)
    {
        var result = await _weatherService.GetCityCoordinatesAsync(cityRequest);
        var response = new ApiResponse<Core.Application.Dtos.OpenMeteo.Geocoding.Root>(result);
        _logger.LogInformation("City coordinates retrieved successfully for {CityName}, {State}", cityRequest.Name.ToUpper(), cityRequest.State.ToUpper());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CoordinatesRequestDto coordenates)
    {
        var result = await _weatherService.GetWeatherAsync(coordenates);
        var response = new ApiResponse<Core.Application.Dtos.OpenMeteo.Root>(result);
        _logger.LogInformation("Weather data retrieved successfully for coordinates: {Latitude}, {Longitude}", coordenates.Latitude, coordenates.Longitude);
        return Ok(response);
    }

    [HttpPost("city-weather")]
    public async Task<ActionResult> GetCityWeatherAsync([FromBody] CityRequestDto cityRequest)
    {
        var result = await _weatherService.GetCityWeatherAsync(cityRequest);
        var response = new ApiResponse<WeatherResponseDto>(result);
        _logger.LogInformation("Weather data retrieved successfully for {CityName}, {State}", cityRequest.Name.ToUpper(), cityRequest.State.ToUpper());
        return Ok(response);
    }
}
