using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadder.Domain;
using SnakesAndLadder.Models;
using System;

namespace SnakesAndLadder.Tests
{
    [TestClass]
    public class BoardServiceTests
    {
        private IBoardService _boardService;
        const int BOARDSIZE = 100;
        [TestInitialize]
        public void TestInitialize()
        {
            _boardService = new BoardService();
        }
        [TestMethod]
        public void Should_Create_Board_For_Given_Size()
        {
            //Act
            _boardService.CreateBoard(BOARDSIZE);

            //Assert
            Assert.AreEqual(_boardService.Board.Length, BOARDSIZE);
        }
        [TestMethod]
        public void Should_Add_Ladder_For_Given_Input()
        {
            //Arrange
            _boardService.CreateBoard(BOARDSIZE);
            int cellNumber = 2;

            //Act
            _boardService.AddLadder(new Ladder()
            {
                CellNumber = cellNumber,
                AdvantageCell = 5
            });

            //Assert
            Assert.AreEqual(_boardService.Board[cellNumber - 1].GetType(), typeof(Ladder));
        }

        [TestMethod]
        public void Should_Throw_Exception_If_CellNumber_Is_LessThan_AdvantageCell()
        {
            //Arrange
            _boardService.CreateBoard(BOARDSIZE);
            int cellNumber = 15;

            //Assert
            var message = Assert.ThrowsException<Exception>(() => _boardService.AddLadder(new Ladder()
            {
                CellNumber = cellNumber,
                AdvantageCell = 5
            }));

            Assert.AreEqual(message.Message, "The ladder must start in a cell in a lower position of the advantage cell");
        }
        [TestMethod]
        public void Should_Add_Snake_For_Given_Input()
        {
            //Arrange
            _boardService.CreateBoard(BOARDSIZE);
            int cellNumber = 20;

            //Act
            _boardService.AddSnake(new Snake()
            {
                CellNumber = cellNumber,
                PenaltyCell = 5
            });

            //Assert
            Assert.AreEqual(_boardService.Board[cellNumber - 1].GetType(), typeof(Snake));
        }

        [TestMethod]
        public void Should_Throw_Exception_If_CellNumber_Is_LessThan_PenaltyCell()
        {
            //Arrange
            _boardService.CreateBoard(BOARDSIZE);
            int cellNumber = 15;

            //Assert
            var message = Assert.ThrowsException<Exception>(() => _boardService.AddSnake(new Snake()
            {
                CellNumber = cellNumber,
                PenaltyCell = 25
            }));

            Assert.AreEqual(message.Message, "The snake must start in a cell in a higer position of the penality cell");
        }
    }
}
