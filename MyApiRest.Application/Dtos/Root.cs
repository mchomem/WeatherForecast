namespace MyApiRest.Application.Dtos;

public class Root
{
    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public required double GenerationtimeMs { get; init; }

    public required int UtcOffsetSeconds { get; init; }

    public required string Timezone { get; init; }

    public required string TimezoneAbbreviation { get; init; }

    public required double Elevation { get; init; }

    public required HourlyUnits HourlyUnits { get; init; }

    public required Hourly Hourly { get; init; }
}