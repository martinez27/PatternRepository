using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;
using PatternRepository.Core.Entities.Enumeration;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Services
{
    public class MovementService : IMovementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<GetMovementDTO> GetAllMovementByUser(DateTime dateTime, int customerId)
        {
           IEnumerable<Movement> movements = _unitOfWork.MovementRepository.GetAllMovementByUser(dateTime, customerId);

            return movements.Cast<Movement>()
                .Select(x=>new GetMovementDTO
                { 
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
