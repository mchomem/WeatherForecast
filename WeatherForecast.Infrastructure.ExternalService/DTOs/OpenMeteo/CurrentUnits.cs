namespace WeatherForecast.Infrastructure.ExternalService.DTOs.OpenMeteo;

public sealed class CurrentUnits
{
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    [JsonPropertyName("interval")]
    public string? Interval { get; set; }

    [JsonPropertyName("temperature_2m")]
    public string? Temperature2m { get; set; }
}
