namespace MyApiRest.Application.Dtos;

public class CoordenatesDto
{
    public string City { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class CoordenatesInsertDto
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
