using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Repository;
using PatternRepository.Infraestructure.Data;

namespace PatternRepository.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppEntitiesContext _context;

        public UnitOfWork(AppEntitiesContext context,
            IAccountRepository accountRepository,
            ICustomerRepository customerRepository,
            IMovementRepository movementRepository            
            )
        {
            _context = context;
            CustomerRepository = customerRepository;
            AccountRepository = accountRepository;
            MovementRepository = movementRepository;            
        }

        public ICustomerRepository CustomerRepository { get; }

        public IAccountRepository AccountRepository { get; }

        public IMovementRepository MovementRepository { get; }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
