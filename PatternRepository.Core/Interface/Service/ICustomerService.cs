using PatternRepository.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Interface.Service
{
    public interface ICustomerService
    {
        void CreateCustomer(SetCustomerDTO customerDTO);
        void UpdateCustomer(SetCustomerDTO customerDTO);
        Task DeleteCustomer(string customerId);
    }
}
