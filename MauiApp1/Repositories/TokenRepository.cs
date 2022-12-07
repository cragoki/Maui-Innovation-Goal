using MauiApp1.Entities;
using MauiApp1.Helpers;
using MauiApp1.Repositories.Interfaces;
using SQLite;

namespace MauiApp1.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private SQLiteConnection conn;
        private void Init()
        {
            var _dbPath = DbHelper.GetLocalFilePath("Localdb");
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Token>();
        }

        public void Add(Token token)
        {
            int result = 0;
            try
            {

                Init();

                result = conn.Insert(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Token token)
        {
            try
            {
                Init();

                conn.Delete(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Token> Get()
        {
            try
            {
                Init();
                return conn.Table<Token>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
