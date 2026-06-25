namespace WeatherForecast.Core.Application.Dtos.City;

public sealed class CityRequestDto
{
    public required string Name { get; init; }

    // TODO: implementar um Enum ou uma string constante contendo o valor por extenso do estado, para evitar inconsistências.
    public required string State { get; init; }
}
