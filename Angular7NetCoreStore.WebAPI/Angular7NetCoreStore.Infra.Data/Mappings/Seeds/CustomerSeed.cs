using Angular7NetCoreStore.Domain.Entities;
using Angular7NetCoreStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Angular7NetCoreStore.Infra.Data.Mappings.Seeds
{
    public static class CustomerSeed
    {
        public static IEnumerable<Customer> GetInitialCustomers()
        {
            var fullName = new FullName("James", "Bond");
            var email = new Email("james.bond@gmail.com");
            var phoneNumber = new PhoneNumber("35", "9123475678");
            var address = new Address("Rua Alameda of Angels", "500", "House", "Center", "Los Angels", "California", "Eua", "123456");
            var customer = new Customer(Guid.NewGuid(), fullName, email, phoneNumber, new DateTime(1991, 7, 9), address);

            return new List<Customer>
            {
                customer
            };
        }
    }
}
