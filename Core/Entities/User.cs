using MauiApp1.Enums;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public UserPermissionLevel PermissionLevel { get; set; }
    }
}
