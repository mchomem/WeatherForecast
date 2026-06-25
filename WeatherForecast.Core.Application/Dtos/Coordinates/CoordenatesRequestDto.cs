namespace WeatherForecast.Core.Application.Dtos.Coordinates;

public sealed class CoordinatesRequestDto
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public Frequency Frequency { get; set; }
}

public enum Frequency
{
    Current = 1,
    Hourly = 2
}