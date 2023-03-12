namespace VendorDeck.API.Config
{
    public class JwtConfig
    {
        public string SecretKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}
