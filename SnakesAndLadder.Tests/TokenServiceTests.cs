using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadder.Domain;
using System.Collections.Generic;

namespace SnakesAndLadder.Tests
{
    [TestClass]
    public class TokenServiceTests
    {
        public ITokenService _tokenService;
        [TestInitialize]
        public void Intialize()
        {
            _tokenService = new TokenService();
        }

        [TestMethod]
        public void Should_Generate_Tokens_In_Range()
        {
            List<int> _tokens = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                _tokens.Add(_tokenService.GetNextToken());
            }

            Assert.IsTrue(_tokens.TrueForAll(token => token <= 6));
        }
    }
}
