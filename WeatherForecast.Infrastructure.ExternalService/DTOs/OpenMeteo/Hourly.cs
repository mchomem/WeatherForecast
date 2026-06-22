namespace WeatherForecast.Infrastructure.ExternalService.OpenMeteo.DTOs;

public class Hourly
{
    [JsonPropertyName("time")]
    public required List<string> Time { get; init; }

    [JsonPropertyName("temperature_2m")]
    public required List<double> Temperature2m { get; init; }
}
