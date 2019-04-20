namespace Angular7NetCoreStore.Domain.ValueObjects
{
    public sealed class FullName
    {
        public FullName(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }
    }
}
