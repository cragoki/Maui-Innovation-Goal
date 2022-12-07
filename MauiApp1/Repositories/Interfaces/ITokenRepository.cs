using MauiApp1.Entities;

namespace MauiApp1.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        void Add(Token token);
        void Delete(Token token);
        List<Token> Get();
    }
}