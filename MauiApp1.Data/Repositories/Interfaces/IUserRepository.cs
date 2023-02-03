using MauiApp1.Data.Entities;

namespace MauiApp1.Data.Repositories.Intefaces
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> Get();
        void Delete(User user);
        User Update(User user);
        void ClearLocalData();
    }
}