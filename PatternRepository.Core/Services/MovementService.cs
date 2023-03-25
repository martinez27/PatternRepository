using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;
using PatternRepository.Core.Entities.Enumeration;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Service;

namespace PatternRepository.Core.Services
{
    public class MovementService : IMovementService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public MovementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<GetMovementDTO> GetAllMovementByUser(DateTime from, DateTime to, string customerId)
        {
            //expression
            //where from.Date >= date && date <= to.Date  && customerId == customerId


            IEnumerable<Movement> movements = _unitOfWork.MovementRepository.GetAllAsync(x => x.Date.Date >= from.Date && x.Date.Date <= to.Date && x.Account.CustomerId == customerId, "Account,Account.Customer");

            return movements.Cast<Movement>()
                .Select(x=>new GetMovementDTO
                {
                    Type = x.Type.ToString(),
                    Date = x.Date,
                    CustomerName = x.Account.Customer.Name,
                    AccountNumber =x.Account.AccountNumber,
                    TypeAccount = Enum.GetName(typeof(AccountType), x.Account.AccounType),
                    InitialBalance = x.Account.Balance,
                    State = x.Account.State,
                    Value = x.Value,
                    Balance = x.Balance,
                });
        }
    }
}