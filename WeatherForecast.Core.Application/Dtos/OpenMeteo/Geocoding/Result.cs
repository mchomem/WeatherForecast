namespace WeatherForecast.Core.Application.Dtos.OpenMeteo.Geocoding;

public sealed class Result
{
    public required long Id { get; init; }

    public required string Name { get; init; }

    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public required double Elevation { get; init; }

    public required string FeatureCode { get; init; }

    public required string CountryCode { get; init; }

    public required long Admin1Id { get; init; }

    public long Admin2Id { get; set; }

    public required string Timezone { get; init; }

    public long Population { get; set; }

    public required long CountryId { get; init; }

    public required string Country { get; init; }

    public required string Admin1 { get; init; }

    public string? Admin2 { get; set; }
}
