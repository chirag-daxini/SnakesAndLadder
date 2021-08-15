using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadder.Domain;
using SnakesAndLadder.Models;

namespace SnakesAndLadder.Tests
{
    [TestClass]
    public class PlayerServiceTests
    {
        private IPlayerService _playerService;
        [TestInitialize]
        public void TestIntialize()
        {
            _playerService = new PlayerService();
        }

        [TestMethod]
        public void Should_Add_Players_For_Valid_Inputs()
        {
            //arrange
            Player objPlayer = new Player();
            objPlayer.PlayerName = "Test";

            //act
            _playerService.AssignPlayers(objPlayer);

            //arrange
            Assert.AreEqual(_playerService.Players[0].PlayerName, objPlayer.PlayerName);
        }
        [TestMethod]
        public void Should_Not_Add_Players_For_Invalid_Value()
        {
            //act
            _playerService.AssignPlayers(null);

            //arrange
            Assert.IsTrue(_playerService.Players.Count == 0);
        }
    }
}
