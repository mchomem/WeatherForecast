namespace WeatherForecast.Infrastructure.ExternalService.DTOs.OpenMeteo;

public sealed class Current
{
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    [JsonPropertyName("interval")]
    public int? Interval { get; set; }

    [JsonPropertyName("temperature_2m")]
    public double? Temperature2m { get; set; }
}
