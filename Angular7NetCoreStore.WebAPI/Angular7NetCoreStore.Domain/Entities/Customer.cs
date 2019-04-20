using Angular7NetCoreStore.Domain.Shared;
using Angular7NetCoreStore.Domain.ValueObjects;
using System;

namespace Angular7NetCoreStore.Domain.Entities
{
    public class Customer : EntityBase
    {
        public Customer(FullName fullName, Email email, PhoneNumber phoneNumber, DateTime birthDate, Address address)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Address = address;
        }

        public Customer(Guid id, FullName fullName, Email email, PhoneNumber phoneNumber, DateTime birthDate, Address address)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Address = address;
        }

        // Empty constructor for EF
        protected Customer()
        {

        }

        public FullName FullName { get; set; }
        public Email Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public DateTime BirthDate { get; private set; }
        public Address Address { get; private set; }
    }
}
