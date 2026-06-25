namespace WeatherForecast.Core.Application.Dtos.OpenMeteo;

public sealed class HourlyUnits
{
    public required string Time { get; init; }

    public required string Temperature2m { get; init; }
}