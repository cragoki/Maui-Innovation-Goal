using MauiApp1.Data.Entities;
using MauiApp1.Data.Repositories.Intefaces;

namespace MauiApp1.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private ILocalMauiContext _context;
        public UserRepository(ILocalMauiContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            int result = 0;
            try
            {
                _context.User.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(User user)
        {
            try
            {
                _context.User.Remove(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<User> Get()
        {
            try
            {
                return _context.User.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User Update(User user)
        {
            var result = new User();
            try
            {
                var entity = _context.User.Where(x => x.Id == user.Id).FirstOrDefault();

                if (entity == null)
                {
                    throw new Exception("Polling Station could not be found");
                }
                else
                {
                    user.Synced = false;
                    entity = user;
                }

                _context.User.Update(entity);
                result = entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public void ClearLocalData() 
        {
        
        }
    }
}
