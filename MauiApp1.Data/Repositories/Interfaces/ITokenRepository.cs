using MauiApp1.Data.Entities;

namespace MauiApp1.Data.Repositories.Intefaces
{
    public interface ITokenRepository
    {
        void Add(Token token);
        void Delete(Token token);
        List<Token> Get();
    }
}