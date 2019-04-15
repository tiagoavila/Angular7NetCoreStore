using Angular7NetCoreStore.Domain.Shared;
using System;

namespace Angular7NetCoreStore.Domain.Entities
{
    public class Address : EntityBase
    {
        public Address(Guid customerId,
            string street,
            string number,
            string complement,
            string district,
            string city,
            string state,
            string country,
            string zipCode)
        {
            CustomerId = customerId;
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        // required by EF
        protected Address()
        {

        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public Guid CustomerId { get; private set; }

        public Customer Customer { get; private set; }
    }
}
