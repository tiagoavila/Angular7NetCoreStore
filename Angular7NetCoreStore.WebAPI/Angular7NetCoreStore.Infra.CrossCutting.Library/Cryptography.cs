using CryptoHelper;

namespace Angular7NetCoreStore.Infra.CrossCutting.Library
{
    public static class Cryptography
    {
        public static string EncryptPassword(string value)
        {
            return Crypto.HashPassword(value);
        }

        public static bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
    }
}
