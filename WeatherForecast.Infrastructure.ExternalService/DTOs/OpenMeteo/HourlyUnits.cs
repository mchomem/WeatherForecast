namespace WeatherForecast.Infrastructure.ExternalService.DTOs.OpenMeteo;

public class HourlyUnits
{
    [JsonPropertyName("time")]
    public required string Time { get; init; }

    [JsonPropertyName("temperature_2m")]
    public required string Temperature2m { get; init; }
}
