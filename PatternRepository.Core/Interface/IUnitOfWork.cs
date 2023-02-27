namespace PatternRepository.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IAccountRepository AccountRepository { get; }
        IMovementRepository MovementRepository { get; }
        IPeopleRepository PeopleRepository { get; }

        //Transacciones
        void SaveChanges();
    }
}
