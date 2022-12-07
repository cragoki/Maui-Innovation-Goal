using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly IMauiContext _context;
        public UserRepository(IMauiContext context)
        {
            _context = context;
        }

        public IQueryable<User> Get()
        {
            return _context.User;
        }

        public void Update(User user)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
