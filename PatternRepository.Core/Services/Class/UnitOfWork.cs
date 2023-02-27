using Microsoft.EntityFrameworkCore;
using PatternRepository.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Services.Class
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public ICustomerRepository Client { get; private set; }
        public IAccountRepository Account { get; private set; }
        public IMovementRepository Movement { get; private set; }

        public UnitOfWork(DbContext dbContext)
        { 
            _dbContext= dbContext;
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
