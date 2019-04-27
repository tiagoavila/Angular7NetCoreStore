using Angular7NetCoreStore.Application.CustomMappings;
using Angular7NetCoreStore.Application.Dtos;
using Angular7NetCoreStore.Application.Interfaces;
using Angular7NetCoreStore.Domain.CommandHandlers;
using Angular7NetCoreStore.Domain.Commands.Inputs;
using Angular7NetCoreStore.Domain.Commands.Outputs;
using Angular7NetCoreStore.Domain.Entities;
using Angular7NetCoreStore.Domain.Interfaces;
using Angular7NetCoreStore.Domain.Shared.Commands;
using Angular7NetCoreStore.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7NetCoreStore.Application
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CustomerCommandHandler _customerCommandHandler;

        public CustomerAppService(ICustomerRepository customerRepository, UserManager<ApplicationUser> userManager, CustomerCommandHandler customerCommandHandler)
        {
            _customerRepository = customerRepository;
            _userManager = userManager;
            _customerCommandHandler = customerCommandHandler;
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            var customerViewModelsList = _customerRepository.GetAll()
                .Select(x => new CustomerDto().InjectFrom(x)).Cast<CustomerDto>();

            return customerViewModelsList;
        }

        public CustomerDto GetById(Guid id)
        {
            var customer = _customerRepository.GetById(id);

            return Mapper.Map<CustomerDto>(customer);
        }

        public CustomerDto GetByEmail(string email)
        {
            var customer = _customerRepository.GetByEmail(email);

            return Mapper.Map<CustomerDto>(customer);
        }

        public async Task<ICommandResult> AddCustomerAsync(AddCustomerDto addCustomerDto)
        {
            var user = new ApplicationUser { UserName = addCustomerDto.Email, Email = addCustomerDto.Email };

            var result = await _userManager.CreateAsync(user, addCustomerDto.Password);
            if (result.Succeeded)
            {
                var createCustomerCommand = Mapper.Map<CreateCustomerCommand>(addCustomerDto);
                var commandResult = _customerCommandHandler.Handle(createCustomerCommand);

                if (commandResult.Success)
                {
                    var customer = (Customer)commandResult.Data;
                    user.CustomerId = customer.Id;
                    await _userManager.UpdateAsync(user);
                }

                return commandResult;
            }

            return new CommandResult(false, result.Errors.Select(e => e.Description));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
