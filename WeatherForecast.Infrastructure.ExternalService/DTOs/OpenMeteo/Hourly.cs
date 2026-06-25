namespace WeatherForecast.Infrastructure.ExternalService.DTOs.OpenMeteo;

public sealed class Hourly
{
    [JsonPropertyName("time")]
    public required List<string> Time { get; init; }

    [JsonPropertyName("temperature_2m")]
    public required List<double> Temperature2m { get; init; }
}
