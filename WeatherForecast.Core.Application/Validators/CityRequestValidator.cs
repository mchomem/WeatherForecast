namespace WeatherForecast.Core.Application.Validators;

public class CityRequestValidator : AbstractValidator<CityRequestDto>
{
    public CityRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O nome da cidade é obrigatório.");

        RuleFor(x => x.State)
            .NotEmpty()
            .WithMessage("O estado da cidade é obrigatório.");
    }
}
