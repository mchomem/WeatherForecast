namespace WeatherForecast.Core.Application.Dtos.Weather;

public sealed class WeatherResponseDto
{
    public required string CityName { get; init; }
    public required string State { get; init; }
    public required string Country { get; init; }
    public required double Latitude { get; init; }
    public required double Longitude { get; init; }
    public required string Timezone { get; init; }
    public required double TemperatureCelsius { get; init; }
    public string TemperatureCelsiusShow
    {
        get => $"{TemperatureCelsius} °C";
    }
    public required double TemperatureFahrenheit { get; init; }
    public string TemperatureFahrenheitShow
    {
        get => $"{TemperatureFahrenheit} °F";
    }
    public required string Summary { get; init; }
}
