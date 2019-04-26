using Angular7NetCoreStore.Application.Dtos;
using Angular7NetCoreStore.Domain.Entities;
using Omu.ValueInjecter;

namespace Angular7NetCoreStore.Application.CustomMappings
{
    public class CustomMappingConfigs
    {
        public static void AddCustomMappings()
        {
            Mapper.AddMap<Customer, CustomerDto>((from) =>
            {
                var target = new CustomerDto();
                target.InjectFrom(from);

                target.Email = from.Email.Address;
                target.PhoneNumber = $"({from.PhoneNumber.AreaCode}) {from.PhoneNumber.Number}";
                target.Complement = from.Address.Complement;
                target.Country = from.Address.Country;
                target.District = from.Address.District;
                target.City = from.Address.City;
                target.Number = from.Address.Number;
                target.State = from.Address.State;
                target.Street = from.Address.Street;
                target.ZipCode = from.Address.ZipCode;

                return target;
            });
        }

    }
}
