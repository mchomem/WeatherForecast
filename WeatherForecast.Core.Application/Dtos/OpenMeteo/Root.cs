namespace WeatherForecast.Core.Application.Dtos.OpenMeteo;

public sealed class Root
{
    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public required double GenerationtimeMs { get; init; }

    public required int UtcOffsetSeconds { get; init; }

    public required string Timezone { get; init; }

    public required string TimezoneAbbreviation { get; init; }

    public required double Elevation { get; init; }

    public HourlyUnits? HourlyUnits { get; set; }

    public Hourly? Hourly { get; set; }

    public CurrentUnits? CurrentUnits { get; set; }

    public Current? Current { get; set; }
}
