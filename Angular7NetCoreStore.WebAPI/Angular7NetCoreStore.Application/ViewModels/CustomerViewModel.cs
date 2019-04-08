using System;

namespace Angular7NetCoreStore.Application.ViewModels
{
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; private set; }
    }
}
