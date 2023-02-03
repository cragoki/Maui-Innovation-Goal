using MauiApp1.Enums;

namespace MauiApp1.Data.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserPermissionLevel PermissionLevel { get; set; }

    }
}
