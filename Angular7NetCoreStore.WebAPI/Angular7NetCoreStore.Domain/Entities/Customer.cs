using Angular7NetCoreStore.Domain.Shared;
using System;
using System.Collections.Generic;

namespace Angular7NetCoreStore.Domain.Entities
{
    public class Customer : EntityBase
    {
        public Customer(Guid id, string name, string email, string phoneNumber, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            _addresses = new List<Address>();
        }

        // Empty constructor for EF
        protected Customer()
        {

        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; private set; }

        private readonly List<Address> _addresses;

        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }
    }
}
