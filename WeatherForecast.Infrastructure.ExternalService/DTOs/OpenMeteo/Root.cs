namespace WeatherForecast.Infrastructure.ExternalService.DTOs.OpenMeteo;

public sealed class Root
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
    public HourlyUnits? HourlyUnits { get; set; }

    [JsonPropertyName("hourly")]
    public Hourly? Hourly { get; set; }

    [JsonPropertyName("current_units")]
    public CurrentUnits? CurrentUnits { get; set; }

    [JsonPropertyName("current")]
    public Current? Current { get; set; }
}
