using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities;
using PatternRepository.Core.Exceptions;
using PatternRepository.Core.Interface;
using PatternRepository.Core.Interface.Service;
using PatternRepository.Core.Interface.Utils;

namespace PatternRepository.Core.Services
{
    //Logica de Negocio
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public CustomerService(IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public void CreateCustomer(SetCustomerDTO customerDTO)
        {
            try
            {
                var existingCustomer = _unitOfWork.CustomerRepository.GetByIdAsync(customerDTO.Id).Result;

                if (existingCustomer != null)
                {
                    throw new BusinessExceptions("El Cliente Existe en el Sistema");
                }
               // var existingCustomer = _unitOfWork.CustomerRepository.GetByIdAsync(x=>x.);
                //Mapeo de DTO a Entidad
                var customer = new Customer
                {
                    Id = customerDTO.Id,
                    Name = customerDTO.Name,
                    Gender = customerDTO.Gender,
                    Age = (int)customerDTO.Age,
                    Address = customerDTO.Address,
                    Phone = customerDTO.Phone,
                    Password = _passwordHasher.Hash(customerDTO.Password),
                    State = true
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

        public async Task DeleteCustomer(string customerId)
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

        public void UpdateCustomer(SetCustomerDTO customerDTO)
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
