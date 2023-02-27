using Microsoft.EntityFrameworkCore;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Services.Interface;
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

        public IClientRepository Client { get; private set; }
        public IAccountRepository Account { get; private set; }
        public IMoveRepository Movement { get; private set; }

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
