using Microsoft.AspNetCore.Mvc;
using Travels.Application.UseCases.AddRoute;
using Travels.Application.UseCases.UpdateRoute;
using Travels.Application.UseCases.GetCheapestRoute;
using Travels.Application.Interfaces.Repositories;
using Travels.Domain.Entities;

namespace Travels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteRepository _routeRepository;
        private readonly AddRouteHandler _addRouteHandler;
        private readonly GetCheapestRouteHandler _getCheapestRouteHandler;
        private readonly UpdateRouteHandler _updateRouteHandler;

        public RoutesController(IRouteRepository routeRepository, 
                                AddRouteHandler addRouteHandler,
                                GetCheapestRouteHandler getCheapestRouteHandler,
                                UpdateRouteHandler updateRouteHandler)
        {
            _routeRepository = routeRepository;
            _addRouteHandler = addRouteHandler;
            _getCheapestRouteHandler = getCheapestRouteHandler;
            _updateRouteHandler = updateRouteHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRouteCommand command)
        {
            var result = await _addRouteHandler.Handle(command);
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(Get), new { id = result.Value?.Id }, result.Value);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRouteCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Route ID mismatch.");
            }

            var result = await _updateRouteHandler.Handle(command);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return NotFound(result.ErrorMessage);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Entities.Route>>> Get()
        {
            var routes = await _routeRepository.GetAllAsync();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Entities.Route>> Get(int id)
        {
            var route = await _routeRepository.GetByIdAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return Ok(route);
        }

        [HttpGet("cheapest/from/{from}/to/{to}")]
        public async Task<IActionResult> GetCheapestRoute(string from, string to)
        {
            var result = await _getCheapestRouteHandler.Handle(from, to);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var route = await _routeRepository.GetByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            await _routeRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
