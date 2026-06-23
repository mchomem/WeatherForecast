namespace WeatherForecast.Test.UnitTest;

// TODO: aplicar um teste melhor...
public class WeatherForecastUnitTest
{
    [Fact]
    public void GetInstance_WeatherForecastModel_ReturnsWeatherForecastModel()
    {
        // Arrange
        var weatherForecast = new WeatherForecastModel();

        // Act
        var result = weatherForecast.GetInstance();

        // Assert
        Assert.IsType<WeatherForecastModel>(result);
    }
}
