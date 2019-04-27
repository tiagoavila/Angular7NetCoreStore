using Angular7NetCoreStore.Domain.Commands.Inputs;
using FluentValidation;

namespace Angular7NetCoreStore.Domain.Validations
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(o => o.CustomerId).NotNull().NotEmpty();
            RuleFor(o => o.Products).NotNull();
            RuleForEach(o => o.Products).SetValidator(new ProductOrderItemValidator());
        }
    }
}
