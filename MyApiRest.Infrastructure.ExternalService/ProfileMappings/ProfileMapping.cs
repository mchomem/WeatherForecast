namespace MyApiRest.Infrastructure.ExternalService.ProfileMappings;

public class ProfileMapping
{
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        config.NewConfig<InfraDto.Root, AppDto.Root>().TwoWays();
        config.NewConfig<InfraDto.Hourly, AppDto.Hourly>().TwoWays();
        config.NewConfig<InfraDto.HourlyUnits, AppDto.HourlyUnits>().TwoWays();        
    }
}
