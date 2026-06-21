namespace MyApiRest.Application.Interfaces;

public interface IWeatherServices
{
    public Task<Root> GetWeatherAsync(CoordenatesInsertDto coordenates);
}
