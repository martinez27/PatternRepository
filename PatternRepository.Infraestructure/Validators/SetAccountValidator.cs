using FluentValidation;
using PatternRepository.Core.DTOs;
using PatternRepository.Core.Entities.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternRepository.Infraestructure.Validators
{
    public class SetAccountValidator : AbstractValidator<SetAccountDTO>
    {
        public SetAccountValidator() { 
        
            RuleFor(x=>x.AccountNumber)
                .NotEmpty().WithMessage("El numero es requerido");

            RuleFor(x => x.TypeAccount)
                .NotEmpty().WithMessage("El Tipo de Cuenta es requerida")
                .IsEnumName(typeof(AccountType),false).WithMessage("El valor {PropertyValue} es inválido");

            RuleFor(x => x.InitialBalance)
                .NotNull().WithMessage("El Saldo Inicial es requerido")
                .GreaterThan(0).WithMessage("Debe ingresar un saldo mayor a 0");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("El id del cliente es requerido");



        }
    }
}
