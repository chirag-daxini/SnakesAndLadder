using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SnakesAndLadder.Domain;
using SnakesAndLadder.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadder.Tests
{
    [TestClass]
    public class GameServiceTests
    {
        private IBoardService _boardService;
        private IPlayerService _playerService;
        private ITokenService _tokenService;
        private IGameService _gameService;
        private GameSettings _gameSettings;

        [TestInitialize]
        public void Intialize()
        {
            _boardService = Substitute.For<IBoardService>();
            _playerService = Substitute.For<IPlayerService>();
            _tokenService = Substitute.For<ITokenService>();
            _gameSettings = Substitute.For<GameSettings>();

            _tokenService.GetNextToken().Returns(new Random().Next(1, 6));
            _playerService.Players.Returns(new List<Player>() {
                new Player() { PlayerName = "Test" }, new Player() { PlayerName = "Test1" }
            });

            var board = new Cell[100];
            for (int i = 0; i < 100; i++)
            {
                Cell c = new Cell
                {
                    CellNumber = i + 1
                };
                board[i] = c;
            }
            _boardService.Board.Returns(board);
            _gameSettings.IntialToken = 1;

            _gameService = new GameService(_boardService, _playerService, _tokenService, _gameSettings);
        }

        [TestMethod]
        public void Should_Check_Configured_Token_Position()
        {
           
        }
    }
}
