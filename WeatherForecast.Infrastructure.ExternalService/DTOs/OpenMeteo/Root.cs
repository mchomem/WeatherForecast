namespace WeatherForecast.Infrastructure.ExternalService.DTOs.OpenMeteo;

public class Root
{
    [JsonPropertyName("latitude")]
    public required double Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public required double Longitude { get; init; }

    [JsonPropertyName("generationtime_ms")]
    public required double GenerationtimeMs { get; init; }

    [JsonPropertyName("utc_offset_seconds")]
    public required int UtcOffsetSeconds { get; init; }

    [JsonPropertyName("timezone")]
    public required string Timezone { get; init; }

    [JsonPropertyName("timezone_abbreviation")]
    public required string TimezoneAbbreviation { get; init; }

    [JsonPropertyName("elevation")]
    public required double Elevation { get; init; }

    [JsonPropertyName("hourly_units")]
    public required HourlyUnits HourlyUnits { get; init; }

    [JsonPropertyName("hourly")]
    public required Hourly Hourly { get; init; }
}
