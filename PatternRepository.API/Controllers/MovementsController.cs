using Microsoft.AspNetCore.Mvc;
using PatternRepository.API.Response;
using PatternRepository.Core.DTOs;
using PatternRepository.Core.Interface.Service;

namespace PatternRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly IMovementService _movementService;

        public MovementsController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [ProducesResponseType(200, Type = typeof(WebApiResponse<IEnumerable<GetMovementDTO>>))]
        [ProducesResponseType(404, Type = typeof(WebApiResponse<IEnumerable<GetMovementDTO>>))]
        [HttpGet("Reportes")]
        public ActionResult<WebApiResponse<IEnumerable<GetMovementDTO>>> GetMovementsByUser(DateTime from, DateTime to, string customerId)
        {
            var movements = _movementService.GetAllMovementByUser(from, to, customerId);
            var response = WebApiResponse<IEnumerable<GetMovementDTO>>.Create(movements, "Proceso ejecutado correctamente");
            if (!movements.Any())
            {
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.Message = "No hay resultados";
            }
            
            return Ok(response);
        }

    }
}
