namespace Travels.Application.UseCases.AddRoute;

public class AddRouteCommand
{
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public decimal Price { get; set; }
}