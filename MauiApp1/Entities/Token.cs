using SQLite;

namespace MauiApp1.Entities
{
    [Table("Token")]
    public class Token : BaseEntity
    {
        public string AuthToken { get; set; }
        public string RefreshToken { get; set; }
        public int UserId { get; set; }
        public DateTime TokenExpiry { get; set; }
    }
}
