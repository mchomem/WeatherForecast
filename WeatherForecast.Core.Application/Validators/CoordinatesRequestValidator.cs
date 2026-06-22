namespace WeatherForecast.Core.Application.Validators;

public class CoordinatesRequestValidator : AbstractValidator<CoordinatesRequestDto>
{
    public CoordinatesRequestValidator()
    {
        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90)
            .WithMessage("Latitude precisa estar entre -90 e 90.");

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180)
            .WithMessage("Longitude precisa estar entre -180 e 180.");
    }
}
