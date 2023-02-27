using PatternRepository.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Interface
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerDTO customerDTO);
        void UpdateCustomer(CustomerDTO customerDTO);
        Task DeleteCustomer(int customerId);
    }
}
