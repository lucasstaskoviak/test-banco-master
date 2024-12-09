using Travels.Application.Common;
using Travels.Application.UseCases.GetCheapestRoute;

namespace Travels.Application.Interfaces;

public interface IGetCheapestRouteCommand
{
    Task<Result<CheapestTravelResponseDto>> FindCheapestRouteAsync(string from, string to);
}
