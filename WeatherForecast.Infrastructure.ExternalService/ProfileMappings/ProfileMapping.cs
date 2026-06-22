namespace WeatherForecast.Infrastructure.ExternalService.ProfileMappings;

public class ProfileMapping
{
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        config.NewConfig<InfraDto.Root, AppOpenMeteoDto.Root>().TwoWays();
        config.NewConfig<InfraDto.Hourly, AppOpenMeteoDto.Hourly>().TwoWays();
        config.NewConfig<InfraDto.HourlyUnits, AppOpenMeteoDto.HourlyUnits>().TwoWays();        
    }
}
