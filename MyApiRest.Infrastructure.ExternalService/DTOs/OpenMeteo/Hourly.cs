namespace MyApiRest.Infrastructure.ExternalService.DTOs.OpenMeteo;

public class Hourly
{
    [JsonPropertyName("time")]
    public required List<string> Time { get; init; }

    [JsonPropertyName("temperature_2m")]
    public required List<double> Temperature2m { get; init; }
}
