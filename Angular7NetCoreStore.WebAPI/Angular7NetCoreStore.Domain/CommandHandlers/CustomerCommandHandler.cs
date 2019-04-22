using Angular7NetCoreStore.Domain.Commands.Inputs;
using Angular7NetCoreStore.Domain.Commands.Outputs;
using Angular7NetCoreStore.Domain.Entities;
using Angular7NetCoreStore.Domain.Interfaces;
using Angular7NetCoreStore.Domain.Shared.Commands;
using Angular7NetCoreStore.Domain.ValueObjects;

namespace Angular7NetCoreStore.Domain.CommandHandlers
{
    public class CustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            if (!command.IsValid())
            {
                return new CommandResult(command.ValidationResult);
            }

            if (_customerRepository.GetByEmail(command.Email) != null)
            {
                return new CommandResult(false, "There is already a customer using this email");
            }

            var fullName = new FullName(command.Name, command.Surname);
            var email = new Email(command.Email);
            var phoneNumber = new PhoneNumber(command.AreaCode, command.PhoneNumber);
            var address = new Address(command.Street, command.Number, command.Complement, command.District, command.City, command.State, command.Country, command.ZipCode);
            var customer = new Customer(fullName, email, phoneNumber, command.BirthDate, address);

            _customerRepository.Add(customer);

            _customerRepository.SaveChanges();

            return new CommandResult(true, "customer successfully registered", customer);
        }
    }
}
