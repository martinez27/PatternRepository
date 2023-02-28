using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;

namespace PatternRepository.Core.Interface.Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
        int GetAccountByCustomer(int id);
        Account GetAccount(string accountNumber);
    }
}
