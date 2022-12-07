using MauiApp1.Enums;
using SQLite;

namespace MauiApp1.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        [MaxLength(250), Unique]
        public string Email { get; set; }
        [MaxLength(250)]
        public string FirstName { get; set; }
        [MaxLength(250)]
        public string LastName { get; set; }
        public UserPermissionLevel PermissionLevel { get; set; }

    }
}
