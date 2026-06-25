namespace WeatherForecast.Core.Application.Dtos.OpenMeteo;

public sealed class Current
{
    public string? Time { get; set; }

    public int? Interval { get; set; }

    public double? Temperature2m { get; set; }
}
