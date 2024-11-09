namespace UserBank.Authentication
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
