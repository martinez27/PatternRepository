using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatternRepository.API.Response;
using PatternRepository.Core.DTOs;
using PatternRepository.Core.Interface.Service;

namespace PatternRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Crear_Cuenta")]
        public ActionResult<WebApiResponse<string>> CreateAcount(SetAccountDTO AccountDTO)
        { 
            _accountService.CreateCustomerAccount(AccountDTO);
            var response = new WebApiResponse<string>($"Cuenta ha creado la cuenta: {AccountDTO.AccountNumber} correctamente");
            return Ok(response);
        }

        [HttpPost("Depositar")]
        public ActionResult<WebApiResponse<string>> CreateDeposit(SetMovementAccountDTO movementAccountDTO)
        { 
            _accountService.GenerateAccountDeposit(movementAccountDTO);
            var response = new WebApiResponse<string>("Deposito se realizo satisfactoriamente");
            return Ok(response);
        }

        [HttpPost("Retirar")]
        public ActionResult<WebApiResponse<string>> CreateWithdrawal(SetMovementAccountDTO movementAccountDTO)
        {
            _accountService.GenerateAccountWithdrawal(movementAccountDTO);
            var response = new WebApiResponse<string>("Retiro se realizo satisfactoriamente");
            return Ok(response);
        }
    }
}
