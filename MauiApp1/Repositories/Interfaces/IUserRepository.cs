using MauiApp1.Entities;

namespace MauiApp1.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> Get();
    }
}