using MauiApp1.Entities;
using MauiApp1.Helpers;
using MauiApp1.Repositories.Interfaces;
using SQLite;

namespace MauiApp1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private SQLiteConnection conn;
        private void Init()
        {
            var _dbPath = DbHelper.GetLocalFilePath("Localdb");
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<User>();
        }

        public void Add(User user)
        {
            int result = 0;
            try
            {

                Init();

                result = conn.Insert(user);
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
                Init();
                return conn.Table<User>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
