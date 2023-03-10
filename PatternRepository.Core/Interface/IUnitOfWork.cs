using PatternRepository.Core.Interface.Repository;

namespace PatternRepository.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IAccountRepository AccountRepository { get; }
        IMovementRepository MovementRepository { get; }

        //Transacciones
        void SaveChanges();
    }
}
