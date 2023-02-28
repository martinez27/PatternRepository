using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    TypeAccount = accountDTO.TypeAccount,
                    InitialBalance = accountDTO.InitialBalance,                    
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
            var account = _unitOfWork.AccountRepository.GetAccount(accountDTO.AccountNumber);

            //Calcular el nuevo saldo
            decimal newBalance = account.InitialBalance + accountDTO.Value;

            //Creamos un nuevo movimiento a la cuenta 
            var movement = new Movement
            {
                Date = DateTime.Now,
                AccountId = account.AccountId,
                TypeMotion = "Deposito",
                Value = accountDTO.Value,
                Balance = newBalance

            };

            //Actualizamos el Valor Inicial 
            account.InitialBalance = newBalance;

            //Actualizamos el Saldo
            _unitOfWork.AccountRepository.Update(account);

            _unitOfWork.SaveChanges();
        }

        public void GenerateAccountWithdrawal(AccountDTO accountDTO)
        {
            throw new NotImplementedException();
        }

        public AccountDTO GetInfoAccount(string accountNumber, string type)
        {
            throw new NotImplementedException();
        }
    }
}
