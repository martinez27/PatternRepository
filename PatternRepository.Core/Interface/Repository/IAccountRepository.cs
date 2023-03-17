using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;

namespace PatternRepository.Core.Interface.Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
        int GetAccountByCustomer(string id);
        Account GetAccount(string accountNumber);
    }
}
