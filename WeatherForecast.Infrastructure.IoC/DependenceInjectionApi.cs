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
            client.DefaultRequestHeaders.Add("User-Agent", "WeatherForecast/1.0");
        });

        #endregion

        #region Validators

        services.AddScoped<IValidator<CoordinatesRequestDto>, CoordinatesRequestValidator>();
        services.AddScoped<IValidator<CityRequestDto>, CityRequestValidator>();

        #endregion

        #region Mapster

        var config = new TypeAdapterConfig();
        WeatherForecast.Infrastructure.ExternalService.ProfileMappings.ProfileMapping.RegisterMappings(config);
        WeatherForecast.Core.Application.ProfileMappings.ProfileMapping.RegisterMappings(config);
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        #endregion
    }

    public static IHostBuilder AddInfrastructureSerilog(this IHostBuilder host)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(
                path: "Logs/WeatherForecast-.log",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 31,
                outputTemplate: "{Timestamp} [{Level}] {Message}{NewLine}{Exception}",
                shared: true)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentName()
            .CreateLogger();

        host.UseSerilog();

        return host;
    }
}
