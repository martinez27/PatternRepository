using PatternRepository.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Interface.Service
{
    public interface IAccountService
    {
        void CreateCustomerAccount(SetAccountDTO accountDTO);
        void GenerateAccountWithdrawal(SetMovementAccountDTO accountDTO);
        void GenerateAccountDeposit(SetMovementAccountDTO accountDTO);
        SetMovementAccountDTO GetInfoAccount(string accountNumber, string type);
    }
}
