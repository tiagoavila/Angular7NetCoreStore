namespace Angular7NetCoreStore.Domain.ValueObjects
{
    public sealed class PhoneNumber
    {
        public PhoneNumber(string areaCode, string number)
        {
            AreaCode = areaCode;
            Number = number;
        }

        public string AreaCode { get; private set; }
        public string Number { get; private set; }

        public override string ToString()
        {
            return ($"({AreaCode}) {Number}");
        }
    }
}
