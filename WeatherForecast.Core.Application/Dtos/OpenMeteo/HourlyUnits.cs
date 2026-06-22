namespace WeatherForecast.Core.Application.OpenMeteo.Dtos;

public class HourlyUnits
{    
    public required string Time { get; init; }

    public required string Temperature2m { get; init; }
}