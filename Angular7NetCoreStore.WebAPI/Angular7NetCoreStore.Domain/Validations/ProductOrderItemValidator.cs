using Angular7NetCoreStore.Domain.Commands.Inputs;
using FluentValidation;

namespace Angular7NetCoreStore.Domain.Validations
{
    public class ProductOrderItemValidator : AbstractValidator<ProductOrderItem>
    {
        public ProductOrderItemValidator()
        {
            RuleFor(p => p.AmountProductToCart).GreaterThan(0);
            RuleFor(p => p.Id).NotNull().NotEmpty();
        }
    }
}
