using Angular7NetCoreStore.Application.Dtos;
using Angular7NetCoreStore.Application.Interfaces;
using Angular7NetCoreStore.Domain.Interfaces;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Angular7NetCoreStore.Application
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            var customerViewModelsList = _customerRepository.GetAll()
                .Select(x => new CustomerDto().InjectFrom(x)).Cast<CustomerDto>();

            return customerViewModelsList;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
