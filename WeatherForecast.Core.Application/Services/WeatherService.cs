namespace WeatherForecast.Core.Application.Services;

public class WeatherService : IWeatherServices
{
    private readonly IOpenMeteoApiClient _openMeteoApiClient;
    private readonly IValidator<CoordinatesRequestDto> _validatorCoordinates;
    private readonly IValidator<CityRequestDto> _validatorCity;
    private readonly IMapper _mapper;

    public WeatherService(IOpenMeteoApiClient openMeteoApiClient,
        IValidator<CoordinatesRequestDto> validatorCoordinates,
        IValidator<CityRequestDto> validatorCity,
        IMapper mapper)
    {
        _openMeteoApiClient = openMeteoApiClient;
        _validatorCoordinates = validatorCoordinates;
        _validatorCity = validatorCity;
        _mapper = mapper;
    }

    public async Task<Dtos.OpenMeteo.Geocoding.Root> GetCityCoordinatesAsync(CityRequestDto cityRequest)
    {
        await _validatorCity.ValidateAndThrowAsync(cityRequest);
        var cityCoordinates = await _openMeteoApiClient.GetCityCoordinatesAsync(cityRequest);
        return cityCoordinates;
    }

    public async Task<Dtos.OpenMeteo.Root> GetWeatherAsync(CoordinatesRequestDto coordinatesRequest)
    {
        await _validatorCoordinates.ValidateAndThrowAsync(coordinatesRequest);
        var weatherData = await _openMeteoApiClient.GetWeatherAsync(coordinatesRequest);
        return weatherData;
    }

    public async Task<Dtos.Weather.WeatherResponseDto> GetCityWeatherAsync(CityRequestDto cityRequest)
    {
        await _validatorCity.ValidateAndThrowAsync(cityRequest);
        var cityCoordinnates = await GetCityCoordinatesAsync(cityRequest);

        if (cityCoordinnates.Results is null || !cityCoordinnates.Results.Any())
            throw new CityCoordinatesNotFoundException();

        var coordinatesRequest = new CoordinatesRequestDto
        {
            Latitude = cityCoordinnates.Results.FirstOrDefault()?.Latitude ?? 0,
            Longitude = cityCoordinnates.Results.FirstOrDefault()?.Longitude ?? 0
        };

        // A API do Open Meteo não aceita coordenadas em formato decimal, por isso os valores são truncados para inteiros antes de fazer a requisição.
        coordinatesRequest.Latitude = Math.Truncate(coordinatesRequest.Latitude);
        coordinatesRequest.Longitude = Math.Truncate(coordinatesRequest.Longitude);

        // Define a frequência da previsão do tempo como "Current" para obter a previsão atual da cidade solicitada.
        coordinatesRequest.Frequency = Frequency.Current;

        var weatherData = await GetWeatherAsync(coordinatesRequest);

        if (weatherData.Current is null || weatherData.Current.Temperature2m is null)
            throw new WeatherNotFoundException();

        var weather = new Weather(
            cityRequest.Name.ToUpper(),
            cityRequest.State.ToUpper(),
            cityCoordinnates.Results.FirstOrDefault()?.Country.ToUpper() ?? string.Empty,
            coordinatesRequest.Latitude,
            coordinatesRequest.Longitude,
            weatherData.Timezone,
            weatherData.Current.Temperature2m.Value);

        weather.GetSummary();
        weather.ConvertToFahrenheit();

        var weatherResponse = _mapper.Map<Dtos.Weather.WeatherResponseDto>(weather);
        return weatherResponse;
    }
}
