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

        /// <summary>
        /// Cria uma nova rota de viagem.
        /// </summary>
        /// <param name="command">Objeto contendo os detalhes da rota.</param>
        /// <returns>Rota criada.</returns>
        /// <response code="201">Retorna a rota criada com sucesso.</response>
        /// <response code="400">Se os dados fornecidos forem inválidos.</response>
        [HttpPost]
        [ProducesResponseType(typeof(AddRouteCommand), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] AddRouteCommand command)
        {
            var result = await _addRouteHandler.Handle(command);
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(Get), new { id = result.Value?.Id }, result.Value);
            }
            return BadRequest(result.Error);
        }

        /// <summary>
        /// Atualiza uma rota de viagem.
        /// </summary>
        /// <param name="command">Objeto contendo os detalhes da rota.</param>
        /// <returns>Rota criada.</returns>
        /// <response code="200">Retorna a rota alterada com sucesso.</response>
        /// <response code="400">Se os dados fornecidos forem inválidos.</response>
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

            return NotFound(result.Error);
        }

        /// <summary>
        /// Obtém todas as rotas cadastradas.
        /// </summary>
        /// <returns>Lista de rotas.</returns>
        /// <response code="200">Retorna a lista de rotas.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Domain.Entities.Route>), 200)]
        public async Task<ActionResult<IEnumerable<Domain.Entities.Route>>> Get()
        {
            var routes = await _routeRepository.GetAllAsync();
            return Ok(routes);
        }

        /// <summary>
        /// Obtém rota específica.
        /// </summary>
        /// <returns>Rota específica.</returns>
        /// <response code="200">Retorna a rota.</response>
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


        /// <summary>
        /// Calcula a rota mais barata entre dois destinos.
        /// </summary>
        /// <param name="from">Local de origem.</param>
        /// <param name="to">Local de destino.</param>
        /// <returns>Rota mais barata.</returns>
        /// <response code="200">Retorna a rota mais barata encontrada.</response>
        /// <response code="404">Se nenhuma rota for encontrada entre os destinos.</response>
        [HttpGet("cheapest/from/{from}/to/{to}")]
        public async Task<IActionResult> GetCheapestRoute(string from, string to)
        {
            var result = await _getCheapestRouteHandler.Handle(from, to);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Error);
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
