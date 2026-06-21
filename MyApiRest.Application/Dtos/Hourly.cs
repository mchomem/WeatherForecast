namespace MyApiRest.Application.Dtos;

public class Hourly
{
    public required List<string> Time { get; init; }

     public required List<double> Temperature2m { get; init; }
}
