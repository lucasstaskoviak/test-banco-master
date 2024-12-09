using Travels.Domain.Entities;
using Travels.Application.Common;
using Travels.Application.UseCases.GetCheapestRoute;

namespace Travels.Application.Interfaces.Repositories;

public interface IRouteRepository
{
    Task AddAsync(Route route);
    Task<List<Route>> GetAllAsync();
    Task<Route?> GetByIdAsync(long id);
    Task DeleteAsync(long id);
    Task UpdateAsync(Route route);
}
