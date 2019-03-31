namespace Angular7NetCoreStore.WebAPI.Models
{
    public class AppSettings
    {
        public AuthenticationSettings AuthenticationSettings { get; set; }
    }

    public class AuthenticationSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
}
