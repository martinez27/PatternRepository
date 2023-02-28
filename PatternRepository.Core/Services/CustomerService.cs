using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Core.Services
{
    //Logica de Negocio
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCustomer(CustomerDTO customerDTO)
        {
            try
            {
                //Mapeo de DTO a Entidad
                var customer = new Customer
                {
                    Name = customerDTO.Name,
                    Gender = customerDTO.Gender,
                    Age = customerDTO.Age,
                    Address = customerDTO.Address,
                    Phone = customerDTO.Phone
                };

                //Agregar entidad Customer
                _unitOfWork.CustomerRepository.Add(customer);

                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteCustomer(int customerId)
        {

            //Consultar Cantidad de Cuentas

            int numberAccount = _unitOfWork.AccountRepository.GetAccountByCustomer(customerId);

            if (numberAccount > 0)
            {
                throw new Exception("El cliente no se puede eliminar porque tiene cuentas actias");
            }

            Customer customer = await _unitOfWork.CustomerRepository.GetByIdAsync(customerId);

            _unitOfWork.CustomerRepository.Delete(customer);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCustomer(CustomerDTO customerDTO)
        {
            //Consultar al Cliente
            
            Customer existCustomer = _unitOfWork.CustomerRepository.GetByIdAsync(customerDTO.Id).Result;

            existCustomer.Address = customerDTO.Address;
            existCustomer.Phone = customerDTO.Phone;
            existCustomer.Password = customerDTO.Password;

            _unitOfWork.SaveChanges();


        }
    }
}
