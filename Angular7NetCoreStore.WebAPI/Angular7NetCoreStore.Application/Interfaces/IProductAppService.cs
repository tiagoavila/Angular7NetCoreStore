using Angular7NetCoreStore.Application.Dtos;
using System;
using System.Collections.Generic;

namespace Angular7NetCoreStore.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        IEnumerable<ProductDto> GetAll();

        ProductDto GetById(Guid id);
    }
}
