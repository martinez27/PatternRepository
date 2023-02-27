using Microsoft.EntityFrameworkCore;
using PatternRepository.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Interface
{
    public interface IClientRepository: IRepository<Customer>
    {
       
    }
}
