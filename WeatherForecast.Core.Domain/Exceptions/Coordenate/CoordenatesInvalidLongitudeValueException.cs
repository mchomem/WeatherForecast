namespace WeatherForecast.Core.Domain.Exceptions.Coordenate;

public class CoordenatesInvalidLongitudeValueException : CoordenatesException
{
    public CoordenatesInvalidLongitudeValueException(string message = DefaultMessages.CoordenateInvalidLongitudeExcption) : base(message) {}
}
