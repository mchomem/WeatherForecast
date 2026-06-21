namespace MyApiRest.Infrastructure.ExternalService.Clients;

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

    public async Task<AppDto.Root> GetWeatherAsync(double latitude, double longitude)
    {
        var urlBase = _configuration.GetSection("ExternalServices:OpenMeteoApi:UrlBase").Value!;
        var response = await _httpClient.GetFromJsonAsync<InfraDto.Root>($"{urlBase}/forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m");
        var rootDto = _mapper.Map<AppDto.Root>(response!);
        return rootDto;
    }
}
