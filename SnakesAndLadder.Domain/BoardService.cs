using SnakesAndLadder.Models;
using System;

namespace SnakesAndLadder.Domain
{
    public interface IBoardService
    {
        void CreateBoard(int boardSize);
        void AddLadder(Ladder ladder);
        void AddSnake(Snake snake);
    }
    public class BoardService : IBoardService
    {
        public Cell[] Board { get; private set; }

        public BoardService()
        {

        }
        public void CreateBoard(int boardSize)
        {
            Board = new Cell[boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                Cell c = new Cell
                {
                    CellNumber = i + 1
                };
                Board[i] = c;
            }
        }
        public void AddLadder(Ladder ladderCell)
        {
            if (ladderCell != null)
                if (ladderCell.CellNumber < ladderCell.AdvantageCell)
                    Board[ladderCell.CellNumber - 1] = ladderCell;
                else
                    throw new Exception("The ladder must start in a cell in a lower position of the advantage cell");

        }
        public void AddSnake(Snake snakeCell)
        {
            if (snakeCell != null)
                if (snakeCell.CellNumber > snakeCell.PenaltyCell)
                    Board[snakeCell.CellNumber - 1] = snakeCell;
                else
                    throw new Exception("The snake must start in a cell in a higer position of the penality cell");

        }

    }
}
