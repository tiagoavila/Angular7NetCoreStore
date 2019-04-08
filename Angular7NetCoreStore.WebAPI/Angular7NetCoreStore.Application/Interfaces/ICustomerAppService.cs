using Angular7NetCoreStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Angular7NetCoreStore.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        IEnumerable<CustomerViewModel> GetAll();
    }
}
