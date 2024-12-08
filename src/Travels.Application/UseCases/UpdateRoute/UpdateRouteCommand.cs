namespace Travels.Application.UseCases.UpdateRoute;

public record UpdateRouteCommand(int Id, string Origin, string Destination, decimal Price);