using Angular7NetCoreStore.Domain.Shared.Commands;
using Angular7NetCoreStore.Domain.Validations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Angular7NetCoreStore.Domain.Commands.Inputs
{
    public class CreateOrderCommand : ICommand
    {
        public Guid CustomerId { get; set; }
        public IEnumerable<ProductOrderItem> Products { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new CreateOrderCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
