namespace WeatherForecast.Api.Controllers;

/// <summary>
/// Controller responsible for handling weather forecast related requests.
/// </summary>
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherServices _weatherService;
    private readonly ILogger<WeatherForecastController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="weatherService">The weather service instance.</param>
    public WeatherForecastController(
        ILogger<WeatherForecastController> logger
        , IWeatherServices weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    /// <summary>
    /// Retrieves the coordinates of a city based on the provided city request.
    /// </summary>
    /// <param name="cityRequest">The city request containing the city name and state.</param>
    /// <returns>The coordinates of the specified city.</returns>
    [HttpPost("city-coordinates")]
    public async Task<IActionResult> GetCityCoordinatesAsync([FromBody] CityRequestDto cityRequest)
    {
        var result = await _weatherService.GetCityCoordinatesAsync(cityRequest);
        var response = new ApiResponse<Core.Application.Dtos.OpenMeteo.Geocoding.Root>(result);
        _logger.LogInformation("City coordinates retrieved successfully for {CityName}, {State}", cityRequest.Name.ToUpper(), cityRequest.State.ToUpper());
        return Ok(response);
    }

    /// <summary>
    /// Retrieves the weather forecast based on the provided coordinates.
    /// </summary>
    /// <param name="coordenates">The coordinates request containing the latitude and longitude.</param>
    /// <returns>The weather forecast for the specified coordinates.</returns>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CoordinatesRequestDto coordenates)
    {
        var result = await _weatherService.GetWeatherAsync(coordenates);
        var response = new ApiResponse<Core.Application.Dtos.OpenMeteo.Root>(result);
        _logger.LogInformation("Weather data retrieved successfully for coordinates: {Latitude}, {Longitude}", coordenates.Latitude, coordenates.Longitude);
        return Ok(response);
    }

    /// <summary>
    /// Retrieves the weather forecast for a specific city based on the provided city request.
    /// </summary>
    /// <param name="cityRequest">The city request containing the city name and state.</param>
    /// <returns>The weather forecast for the specified city.</returns>
    [HttpPost("city-weather")]
    public async Task<ActionResult> GetCityWeatherAsync([FromBody] CityRequestDto cityRequest)
    {
        var result = await _weatherService.GetCityWeatherAsync(cityRequest);
        var response = new ApiResponse<WeatherResponseDto>(result);
        _logger.LogInformation("Weather data retrieved successfully for {CityName}, {State}", cityRequest.Name.ToUpper(), cityRequest.State.ToUpper());
        return Ok(response);
    }
}
