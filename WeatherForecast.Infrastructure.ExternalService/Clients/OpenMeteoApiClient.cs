namespace WeatherForecast.Infrastructure.ExternalService.Clients;

public class OpenMeteoApiClient : IOpenMeteoApiClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public OpenMeteoApiClient(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<AppOpenMeteoDto.Root> GetWeatherAsync(AppCoordinatesDto.CoordinatesRequestDto coordinates)
    {
        var urlBase = _configuration.GetSection("ExternalServices:OpenMeteoApi:UrlBase").Value!;
        var response = await _httpClient.GetFromJsonAsync<InfraDto.Root>($"{urlBase}/forecast?latitude={coordinates.Latitude}&longitude={coordinates.Longitude}&hourly=temperature_2m");
        var rootDto = _mapper.Map<AppOpenMeteoDto.Root>(response!);
        return rootDto;
    }
}
