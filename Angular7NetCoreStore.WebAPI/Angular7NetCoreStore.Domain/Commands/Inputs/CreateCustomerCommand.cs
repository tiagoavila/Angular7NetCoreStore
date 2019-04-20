using Angular7NetCoreStore.Domain.Shared.Commands;
using Angular7NetCoreStore.Domain.Validations;
using FluentValidation.Results;
using System;

namespace Angular7NetCoreStore.Domain.Commands.Inputs
{
    public class CreateCustomerCommand : ICommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new CreateCustomerCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
