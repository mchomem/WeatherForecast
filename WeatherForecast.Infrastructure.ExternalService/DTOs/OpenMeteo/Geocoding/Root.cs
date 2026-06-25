namespace WeatherForecast.Infrastructure.ExternalService.DTOs.OpenMeteo.Geocoding;

public sealed class Root
{
    [JsonPropertyName("results")]
    public List<Result>? Results { get; set; }

    [JsonPropertyName("generationtime_ms")]
    public double GenerationtimeMs { get; set; }
}