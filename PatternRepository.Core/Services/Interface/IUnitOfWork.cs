using PatternRepository.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Services.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Client { get; }
        IAccountRepository Account { get; }
        IMoveRepository Movement { get; }
        int Complete();
    }
}
