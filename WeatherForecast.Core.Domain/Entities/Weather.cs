namespace WeatherForecast.Core.Domain.Entities;

public sealed class Weather
{
    public Weather(string cityName, string state, string country, double latitude, double longitude, string timezone, double temperatureCelsius)
    {
        CityName = cityName;
        State = state;
        Country = country;
        Latitude = latitude;
        Longitude = longitude;
        Timezone = timezone;
        TemperatureCelsius = temperatureCelsius;
    }

    public string CityName { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public string Timezone { get; private set; }
    public double TemperatureCelsius { get; private set; }
    public double? TemperatureFahrenheit { get; private set; }
    public string? Summary { get; private set; }

    public void ConvertToFahrenheit()
    {
        TemperatureFahrenheit = (TemperatureCelsius * 9 / 5) + 32;
    }

    public void GetSummary()
    {
        switch (TemperatureCelsius)
        {
            case < 0:
                Summary = "Congelante";
                break;

            case >= 0 and <= 10:
                Summary = "Muito Frio";
                break;

            case > 10 and <= 18:
                Summary = "Frio";
                break;

            case > 18 and <= 24:
                Summary = "Agradável";
                break;

            case > 24 and <= 30:
                Summary = "Quente";
                break;

            case > 30 and <= 40:
                Summary = "Muito Quente";
                break;

            case > 40:
                Summary = "Perigoso";
                break;

            default:
                Summary = "Congelante";
                break;
        }
    }
}