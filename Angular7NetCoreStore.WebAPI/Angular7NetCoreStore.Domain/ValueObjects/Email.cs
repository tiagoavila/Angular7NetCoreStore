namespace Angular7NetCoreStore.Domain.ValueObjects
{
    public sealed class Email
    {
        public Email(string address)
        {
            Address = address;

            //AddNotifications(new ValidationContract()
            //    .Requires()
            //    .IsEmail(Address, "Email", "O E-mail é inválido")
            //);
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
