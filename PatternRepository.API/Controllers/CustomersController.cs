using Microsoft.AspNetCore.Mvc;
using PatternRepository.API.Response;
using PatternRepository.Core.DTOs;
using PatternRepository.Core.Interface.Service;

namespace PatternRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        ///     Crear Cliente
        /// </summary>
        /// <param name="customerDTO"></param>
        /// <returns></returns>
        [HttpPost("Crear_Cliente")]
        public ActionResult<WebApiResponse<string>> CreateCustomer(SetCustomerDTO customerDTO)
        { 
            _customerService.CreateCustomer(customerDTO);
            var response = WebApiResponse<string>.Create("Cliente Creado Correctamente");
            return Ok(response);
        }
    }
}
