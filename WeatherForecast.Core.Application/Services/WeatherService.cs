namespace WeatherForecast.Core.Application.Services;

public class WeatherService : IWeatherServices
{
    private readonly IOpenMeteoApiClient _openMeteoApiClient;
    private readonly IValidator<CoordinatesRequestDto> _validatorCoordinates;

    public WeatherService(IOpenMeteoApiClient openMeteoApiClient, IValidator<CoordinatesRequestDto> validatorCoordinates)
    {
        _openMeteoApiClient = openMeteoApiClient;
        _validatorCoordinates = validatorCoordinates;
    }

    public async Task<Dtos.OpenMeteo.Geocoding.Root> GetCityCoordinatesAsync(CityRequestDto cityRequest)
    {
        var cityCoordinates = await _openMeteoApiClient.GetCityCoordinatesAsync(cityRequest);
        return cityCoordinates;
    }

    public async Task<Dtos.OpenMeteo.Root> GetWeatherAsync(CoordinatesRequestDto coordenates)
    {
        await _validatorCoordinates.ValidateAndThrowAsync(coordenates);
        var weatherData = await _openMeteoApiClient.GetWeatherAsync(coordenates);
        return weatherData;
    }

    public async Task<Dtos.Weather.WeatherResponseDto> GetCityWeatherAsync(CityRequestDto cityRequest)
    {
        var cityCoordinnates = await GetCityCoordinatesAsync(cityRequest);

        var coordinatesRequest = new CoordinatesRequestDto
        {
            Latitude = cityCoordinnates.Results.FirstOrDefault()?.Latitude ?? 0,
            Longitude = cityCoordinnates.Results.FirstOrDefault()?.Longitude ?? 0
        };

        coordinatesRequest.Latitude = Math.Truncate(coordinatesRequest.Latitude);
        coordinatesRequest.Longitude = Math.Truncate(coordinatesRequest.Longitude);
        coordinatesRequest.Frequency = Frequency.Current;

        var weatherData = await GetWeatherAsync(coordinatesRequest);
        var weatherResponse = new Dtos.Weather.WeatherResponseDto
        {
            CityName = cityRequest.Name,
            State = cityRequest.State,
            Country = cityCoordinnates.Results.FirstOrDefault()?.Country ?? string.Empty,
            Latitude = coordinatesRequest.Latitude,
            Longitude = coordinatesRequest.Longitude,
            Timezone = weatherData.Timezone,
            TemperatureCelsius = weatherData.Current?.Temperature2m ?? 0,
            TemperatureFahrenheit = weatherData.Current != null ? (weatherData.Current.Temperature2m.Value * 9 / 5) + 32 : 0,
            Summary = GetSummary(weatherData.Current?.Temperature2m ?? 0)
        };

        return weatherResponse;
    }

    private static string GetSummary(double temperatureC)
    {
        switch (temperatureC)
        {
            case < 0:
                return "Congelante";
            case >= 0 and <= 10:
                return "Muito Frio";
            case > 10 and <= 18:
                return "Frio";
            case > 18 and <= 24:
                return "Agradável";
            case > 24 and <= 30:
                return "Quente";
            case > 30 and <= 40:
                return "Muito Quente";
            case > 40:
                return "Perigoso";
            default:
                return "Congelante";
        }
    }
}
