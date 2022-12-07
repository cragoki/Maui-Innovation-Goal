namespace SharedComponents.Model
{
    public class TokenModel
    {
        public int UserId { get; set; }
        public string AuthToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpiry { get; set; }

    }
}
