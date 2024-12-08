using Travels.Application.Common;
using Travels.Application.Interfaces.Repositories;
using Travels.Domain.Entities;

namespace Travels.Application.UseCases.UpdateRoute;

public class UpdateRouteHandler
{
    private readonly IRouteRepository _repository;

    public UpdateRouteHandler(IRouteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Route>> Handle(UpdateRouteCommand command)
    {
        var existingRoute = await _repository.GetByIdAsync(command.Id);
        if (existingRoute == null)
        {
            return Result<Route>.Failure("Route not found.");
        }

        existingRoute.Origin = command.Origin;
        existingRoute.Destination = command.Destination;
        existingRoute.Price = command.Price;

        await _repository.UpdateAsync(existingRoute);

        return Result<Route>.Success(existingRoute);
    }
}
