using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        void Delete(int id);
        IQueryable<User> Get();
        void Update(User user);
    }
}