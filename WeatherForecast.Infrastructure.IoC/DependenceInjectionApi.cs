namespace WeatherForecast.Infrastructure.IoC;

public static class DependenceInjectionApi
{
    public static void AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
    {
        #region Services

        services.AddScoped<IWeatherServices, WeatherService>();

        #endregion

        #region External Services

        services.AddHttpClient<IOpenMeteoApiClient, OpenMeteoApiClient>(client =>
        {
            client.BaseAddress = new Uri(configuration["ExternalServices:OpenMeteoApi:UrlBase"] ?? string.Empty);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "WeatherForecast");
        });

        #endregion

        #region Validators

        services.AddScoped<IValidator<CoordinatesRequestDto>, CoordinatesRequestValidator>();

        #endregion

        #region Mapster

        var config = new TypeAdapterConfig();
        ProfileMapping.RegisterMappings(config);
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddMapster();
    
        #endregion
    }
}
