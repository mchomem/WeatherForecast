namespace WeatherForecast.Core.Application.Interfaces;

public interface IWeatherServices
{
    public Task<Root> GetWeatherAsync(CoordinatesRequestDto coordenates);
}
