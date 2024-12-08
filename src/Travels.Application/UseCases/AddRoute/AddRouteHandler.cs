using Travels.Application.Interfaces.Repositories;
using Travels.Application.Common;
using Travels.Domain.Entities;

namespace Travels.Application.UseCases.AddRoute
{
    public class AddRouteHandler
    {
        private readonly IRouteRepository _repository;

        public AddRouteHandler(IRouteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Route>> Handle(AddRouteCommand command)
        {
            try
            {
                var route = new Route(command.Origin, command.Destination, command.Price);
                await _repository.AddAsync(route);

                return Result<Route>.Success(route);
            }
            catch (Exception ex)
            {
                return Result<Route>.Failure($"An error occurred: {ex.Message}");
            }
        }
    }
}
