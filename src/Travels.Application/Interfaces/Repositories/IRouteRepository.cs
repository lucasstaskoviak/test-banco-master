using Travels.Domain.Entities;

namespace Travels.Application.Interfaces.Repositories;

public interface IRouteRepository
{
    Task AddAsync(Route route);
    Task<List<Route>> GetAllAsync();
    Task<Route?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task UpdateAsync(Route route);
}
