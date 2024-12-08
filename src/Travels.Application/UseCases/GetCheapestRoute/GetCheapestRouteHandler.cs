using Travels.Application.Interfaces.Services;
using Travels.Application.Common;
using Travels.Application.DTOs;

namespace Travels.Application.UseCases.GetCheapestRoute;

public class GetCheapestRouteHandler
{
    private readonly ICheapestRouteFinder _routeFinder;

    public GetCheapestRouteHandler(ICheapestRouteFinder routeFinder)
    {
        _routeFinder = routeFinder;
    }

    public async Task<Result<CheapestTravelResponseDto>> Handle(string from, string to)
    {
        return await _routeFinder.FindCheapestRouteAsync(from, to);
    }
}
