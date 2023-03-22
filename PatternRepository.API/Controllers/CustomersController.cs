using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateCustomer(SetCustomerDTO customerDTO)
        { 
            _customerService.CreateCustomer(customerDTO);
            return Ok("Cliente Creado Correctamente");
        }
    }
}
