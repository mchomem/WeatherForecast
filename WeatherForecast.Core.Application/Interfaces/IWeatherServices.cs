namespace WeatherForecast.Core.Application.Interfaces;

public interface IWeatherServices
{
    public Task<Dtos.OpenMeteo.Geocoding.Root> GetCityCoordinatesAsync(CityRequestDto cityRequest);
    public Task<Dtos.OpenMeteo.Root> GetWeatherAsync(CoordinatesRequestDto coordinatesRequest);
    public Task<Dtos.Weather.WeatherResponseDto> GetCityWeatherAsync(CityRequestDto cityRequest);
}
