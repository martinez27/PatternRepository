using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;
using PatternRepository.Core.Entities.Enumeration;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Service;

namespace PatternRepository.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCustomerAccount(SetAccountDTO accountDTO)
        {
            try
            {
                //Mapeo de DTO a Entidad
                var account = new Account
                {
                    AccountNumber = accountDTO.AccountNumber,
                    AccounType = (AccountType)Enum.Parse(typeof(AccountType), accountDTO.TypeAccount),
                    Balance = accountDTO.InitialBalance,                    
                    CustomerId = accountDTO.CustomerId
                };

                //Agregar entidad Account
                _unitOfWork.AccountRepository.Add(account);

                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GenerateAccountDeposit(AccountDTO accountDTO)
        {
            //Buscamos numero de cuenta
            Account account = _unitOfWork.AccountRepository.GetAccount(accountDTO.AccountNumber);

            //Calcular el nuevo saldo
            decimal newBalance = account.Balance + accountDTO.Value;

            //Creamos un nuevo movimiento a la cuenta 
            var movement = new Movement
            {
                Date = DateTime.Now,
                AccountId = account.AccountNumber,
                Type = MovementType.Deposito,
                Value = accountDTO.Value,
                Balance = newBalance

            };

            _unitOfWork.MovementRepository.Add(movement);
            //Actualizamos el Valor Inicial 
            account.Balance = newBalance;

            //Actualizamos el Saldo
            _unitOfWork.AccountRepository.Update(account);

            _unitOfWork.SaveChanges();
        }

        public void GenerateAccountWithdrawal(AccountDTO accountDTO)
        {
            //Buscamos numero de cuenta
            Account account = _unitOfWork.AccountRepository.GetAccount(accountDTO.AccountNumber);

            //Saldo disponible
            if (accountDTO.Value > account.Balance)
            {
                throw new Exception("Saldo no disponible");
            }

            //Calcular el nuevo saldo
            decimal newBalance = account.Balance - accountDTO.Value;


            //Creamos un nuevo movimiento a la cuenta 
            var movement = new Movement
            {
                Date = DateTime.Now,
                AccountId = account.AccountNumber,
                Type = MovementType.Retiro,
                Value = accountDTO.Value,
                Balance = newBalance

            };

            _unitOfWork.MovementRepository.Add(movement);
            //Actualizamos el Valor Inicial 
            account.Balance = newBalance;

            //Actualizamos el Saldo
            _unitOfWork.AccountRepository.Update(account);

            _unitOfWork.SaveChanges();
        }

        public AccountDTO GetInfoAccount(string accountNumber, string type)
        {
            Account account = _unitOfWork.AccountRepository.GetAccount(accountNumber);

            return new AccountDTO
            {
                AccountNumber = accountNumber,
                CustomerId = account.CustomerId,
                State = account.State,
                TypeAccount = Enum.GetName(typeof(AccountType), account.AccounType.ToString()),
                Value = account.Balance
            };
        }
    }
}
