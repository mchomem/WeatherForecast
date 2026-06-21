namespace MyApiRest.Application.Services;

public class WeatherService : IWeatherServices
{
    private readonly IOpenMeteoApiClient _openMeteoApiClient;

    public WeatherService(IOpenMeteoApiClient openMeteoApiClient)
    {
        _openMeteoApiClient = openMeteoApiClient;
    }

    private void CheckValues(CoordenatesInsertDto coordenates)
    {
        if (coordenates.Latitude < -90 || coordenates.Latitude > 90)
            throw new CoordenatesInvalidLatitudeValueException();

        if (coordenates.Longitude < -180 || coordenates.Longitude > 180)
            throw new CoordenatesInvalidLongitudeValueException();
    }

    public async Task<Root> GetWeatherAsync(CoordenatesInsertDto coordenates)
    {
        CheckValues(coordenates);

        var weatherData = await _openMeteoApiClient.GetWeatherAsync(coordenates.Latitude, coordenates.Longitude);

        return weatherData;
    }
}
