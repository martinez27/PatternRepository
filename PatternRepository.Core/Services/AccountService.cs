using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;
using PatternRepository.Core.Interface;
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

        public void CreateAccount(AccountDTO accountDTO)
        {
            try
            {
                //Mapeo de DTO a Entidad
                var account = new Account
                {
                  AccountNumber = accountDTO.AccountNumber,
                  TypeAccount = accountDTO.TypeAccount,
                  InitialBalance = accountDTO.InitialBalance,
                  State = accountDTO.State,
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

        public async Task DeleteAccount(int accountId)
        {
            int numberAccount = _unitOfWork.AccountRepository.GetAccountByCustomer(accountId);

            if (numberAccount > 0)
            {
                throw new Exception("La cuenta no se puede eliminar porque tiene cuentas actias");
            }

            Account account = await _unitOfWork.AccountRepository.GetByIdAsync(accountId);

            _unitOfWork.AccountRepository.Delete(account);
            _unitOfWork.SaveChanges();
        }

        public void UpdateAccount(AccountDTO accountDTO)
        {
            //Consultar al Cliente

            Account existAccount = _unitOfWork.AccountRepository.GetByIdAsync(accountDTO.Id).Result;

            existAccount.State = accountDTO.State;
            existAccount.InitialBalance = accountDTO.InitialBalance;

            _unitOfWork.SaveChanges();
        }
    }
}
