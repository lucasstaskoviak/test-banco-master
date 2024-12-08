using Travels.Application.Common;
using Travels.Application.DTOs;

namespace Travels.Application.Interfaces.Services;

public interface ICheapestRouteFinder
{
    Task<Result<CheapestTravelResponseDto>> FindCheapestRouteAsync(string from, string to);
}
