using MauiApp1.Data.Entities;
using MauiApp1.Data.Repositories.Intefaces;

namespace MauiApp1.Data.Repositories
{
    public class TokenRepository : ITokenRepository
    {

        private ILocalMauiContext _context;
        public TokenRepository(ILocalMauiContext context)
        {
            _context = context;
        }

        public void Add(Token token)
        {
            int result = 0;
            try
            {
                _context.Token.Add(token);
                _context.SaveChangesAsync();
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
                _context.Token.Remove(token);
                _context.SaveChangesAsync();
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
                return _context.Token.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
