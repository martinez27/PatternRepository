using FluentValidation;
using PatternRepository.Core.DTOs;

namespace PatternRepository.Infraestructure.Validation
{
    public class SetCustomerValidator : AbstractValidator<SetCustomerDTO>
    {
        public SetCustomerValidator()
        {
            //Validar ID    
            RuleFor(x => x.Id).NotEmpty().WithMessage("El ID es requerido");
            RuleFor(x => x.Name).NotEmpty().WithMessage("El Nombre es requerido");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("El Genero es requerido");
            RuleFor(x => x.Age).NotEmpty().WithMessage("La edad es requerida").GreaterThanOrEqualTo((byte)18).WithMessage("La edad minima es 18 años");
            RuleFor(x => x.Address).NotEmpty().WithMessage("La Direccion del cliente es requerido");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("El Telefono es requerido");
            RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña del cliente es requerido").Matches("^(\\d{4})$").WithMessage("La contraseña tiene el formato incorrecto");
        }
    }
}
