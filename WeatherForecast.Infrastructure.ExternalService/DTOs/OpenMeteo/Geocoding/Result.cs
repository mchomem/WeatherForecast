namespace WeatherForecast.Infrastructure.ExternalService.DTOs.OpenMeteo.Geocoding;

public sealed class Result
{
    [JsonPropertyName("id")]
    public required long Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("latitude")]
    public required double Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public required double Longitude { get; init; }

    [JsonPropertyName("elevation")]
    public required double Elevation { get; init; }

    [JsonPropertyName("feature_code")]
    public required string FeatureCode { get; init; }

    [JsonPropertyName("country_code")]
    public required string CountryCode { get; init; }

    [JsonPropertyName("admin1_id")]
    public required long Admin1Id { get; init; }

    [JsonPropertyName("admin2_id")]
    public long Admin2Id { get; set; }

    [JsonPropertyName("timezone")]
    public required string Timezone { get; init; }

    [JsonPropertyName("population")]
    public long Population { get; set; }

    [JsonPropertyName("country_id")]
    public required long CountryId { get; init; }

    [JsonPropertyName("country")]
    public required string Country { get; init; }

    [JsonPropertyName("admin1")]
    public required string Admin1 { get; init; }

    [JsonPropertyName("admin2")]
    public string? Admin2 { get; set; }
}
