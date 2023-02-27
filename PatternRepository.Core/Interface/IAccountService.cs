using PatternRepository.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Interface
{
    public interface IAccountService
    {
        void CreateAccount(AccountDTO accountDTO);
        void UpdateAccount(AccountDTO accountDTO);
        Task DeleteAccount(int accountId);
    }
}
