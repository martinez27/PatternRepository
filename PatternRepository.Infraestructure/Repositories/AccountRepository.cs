using PatternRepository.Core.Entities;
using PatternRepository.Core.Interface.Repository;
using PatternRepository.Infraestructure.Data;

namespace PatternRepository.Infraestructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly AppEntitiesContext _context;
        public AccountRepository(AppEntitiesContext context) : base(context)
        {
            _context = context;
        }

        public Account GetAccount(string accountNumber)
        {
            return _context.Accounts.Find(accountNumber);
        }

        public int GetAccountByCustomer(string id)
        {
            return _context.Accounts.Where(x=>x.CustomerId == id).Count();
        }
    }
}
