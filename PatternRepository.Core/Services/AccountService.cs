using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;
using PatternRepository.Core.Entities.Enumeration;
using PatternRepository.Core.Exceptions;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Service;
using PatternRepository.Core.Interface.Utils;

namespace PatternRepository.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public AccountService(IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public void CreateCustomerAccount(SetAccountDTO accountDTO)
        {
            Account existingAccount = _unitOfWork.AccountRepository.GetAccount(accountDTO.AccountNumber);

            if (existingAccount != null) 
            {
                throw new BusinessExceptions($"La cuenta {existingAccount.AccountNumber} ya existe");
            }

            try
            {
                //Mapeo de DTO a Entidad
                var account = new Account
                {
                    AccountNumber = accountDTO.AccountNumber,
                    AccounType = (AccountType)Enum.Parse(typeof(AccountType), accountDTO.TypeAccount),
                    Balance = accountDTO.InitialBalance,                    
                    CustomerId = accountDTO.CustomerId,
                    State = true
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

        public void GenerateAccountDeposit(SetMovementAccountDTO accountDTO)
        {
            //Buscamos numero de cuenta
            Account account = _unitOfWork.AccountRepository.GetAccount(accountDTO.AccountNumber);

            if (account == null) 
                throw new BusinessExceptions("Cuenta No Existe");

            if (account.State == false)
                throw new BusinessExceptions("Cuenta Inactiva");

            Customer customer = _unitOfWork.CustomerRepository.GetByIdAsync(accountDTO.CustomerId).Result;

            if (account.State == false)
                throw new BusinessExceptions("Cliente Inactivo");

            if (account.CustomerId != customer.Id)
                throw new BusinessExceptions("El Cliente No Es Propietario de la Cuenta");

            if (customer == null)
                throw new BusinessExceptions("El Cliente No Existe");

            //if (accountDTO.UserPassword != customer?.Password)
            if (!_passwordHasher.Check(customer.Password, accountDTO.UserPassword))
                throw new BusinessExceptions("Contraseña Incorrecta");

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

        public void GenerateAccountWithdrawal(SetMovementAccountDTO accountDTO)
        {
            //Buscamos numero de cuenta
            Account account = _unitOfWork.AccountRepository.GetAccount(accountDTO.AccountNumber);

            if (account == null)
                throw new BusinessExceptions("Cuenta No Existe");

            if (account.State == false)
                throw new BusinessExceptions("Cuenta Inactiva");

            Customer customer = _unitOfWork.CustomerRepository.GetByIdAsync(accountDTO.CustomerId).Result;

            if (account.State == false)
                throw new BusinessExceptions("Cliente Inactivo");

            if (customer == null)
                throw new BusinessExceptions("El Cliente No Existe");

            if (account.CustomerId != customer.Id)
                throw new BusinessExceptions("El Cliente No Es Propietario de la Cuemta");

            if (!_passwordHasher.Check(customer.Password, accountDTO.UserPassword))
                throw new BusinessExceptions("Contraseña Incorrecta");

            //Saldo disponible
            if (accountDTO.Value > account.Balance)
                throw new Exception("Saldo no disponible");

            //Calcular el nuevo saldo
            decimal newBalance = account.Balance - accountDTO.Value;


            //Creamos un nuevo movimiento a la cuenta 
            var movement = new Movement
            {
                Date = DateTime.Now,
                AccountId = account.AccountNumber,
                Type = MovementType.Retiro,
                Value = decimal.Negate(accountDTO.Value),
                Balance = newBalance

            };

            _unitOfWork.MovementRepository.Add(movement);
            //Actualizamos el Valor Inicial 
            account.Balance = newBalance;

            //Actualizamos el Saldo
            _unitOfWork.AccountRepository.Update(account);

            _unitOfWork.SaveChanges();
        }

        public SetMovementAccountDTO GetInfoAccount(string accountNumber, string type)
        {
            Account account = _unitOfWork.AccountRepository.GetAccount(accountNumber);

            return new SetMovementAccountDTO
            {
                AccountNumber = accountNumber,
                CustomerId = account.CustomerId,
                //State = account.State,
                TypeAccount = Enum.GetName(typeof(AccountType), account.AccounType.ToString()),
                Value = account.Balance
            };
        }
    }
}
