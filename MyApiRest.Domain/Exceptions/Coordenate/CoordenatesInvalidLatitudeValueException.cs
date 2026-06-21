namespace MyApiRest.Domain.Exceptions.Coordenate;

public class CoordenatesInvalidLatitudeValueException : CoordenatesException
{
    public CoordenatesInvalidLatitudeValueException(string message = DefaultMessages.CoordenateInvalidLatitudeExcption) : base(message) { }
}
