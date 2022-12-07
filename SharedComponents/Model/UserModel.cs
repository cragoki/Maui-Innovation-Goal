using MauiApp1.Enums;

namespace SharedComponents.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserPermissionLevel PermissionLevel { get; set; }
    }
}
