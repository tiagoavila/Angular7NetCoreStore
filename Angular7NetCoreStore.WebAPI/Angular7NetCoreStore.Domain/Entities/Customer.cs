using Angular7NetCoreStore.Domain.Shared;
using System;

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
        }

        // Empty constructor for EF
        protected Customer()
        {

        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; private set; }
    }
}
