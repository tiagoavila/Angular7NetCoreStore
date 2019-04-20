using Angular7NetCoreStore.Domain.Commands.Inputs;
using FluentValidation;

namespace Angular7NetCoreStore.Domain.Validations
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
            RuleFor(c => c.Surname).NotNull().NotEmpty();
            RuleFor(c => c.Email).NotNull().NotEmpty();
            RuleFor(c => c.AreaCode).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(c => c.PhoneNumber).NotNull().NotEmpty().MinimumLength(9);
            RuleFor(c => c.Street).NotNull().NotEmpty();
            RuleFor(c => c.Number).NotNull().NotEmpty();
            RuleFor(c => c.District).NotNull().NotEmpty();
            RuleFor(c => c.City).NotNull().NotEmpty();
            RuleFor(c => c.State).NotNull().NotEmpty();
            RuleFor(c => c.Country).NotNull().NotEmpty();
            RuleFor(c => c.ZipCode).NotNull().NotEmpty();
        }
    }
}
