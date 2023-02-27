using PatternRepository.Core.Entities;

namespace PatternRepository.Core.Interface
{
    public interface IAccountRepository : IRepository<Account>
    {
        int AccountByCustomer(int id);
    }
}
