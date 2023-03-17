using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Repository;
using PatternRepository.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppEntitiesContext _context;

        public UnitOfWork(AppEntitiesContext context)
        {
            _context = context;
        }

        //Campos privados

        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMovementRepository _movementRepository;

        public ICustomerRepository CustomerRepository => _customerRepository ?? new CustomerRepository(_context);

        public IAccountRepository AccountRepository =>  _accountRepository ?? new AccountRepository(_context);

        public IMovementRepository MovementRepository => _movementRepository ?? new MovementRepository(_context);

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
