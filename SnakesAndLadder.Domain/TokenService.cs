using System;

namespace SnakesAndLadder.Domain
{
    public interface ITokenService
    {
        int GetNextToken();
    }
    public class TokenService : ITokenService
    {
        public int GetNextToken()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }
    }
}
