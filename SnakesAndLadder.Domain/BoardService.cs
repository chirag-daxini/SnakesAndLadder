using SnakesAndLadder.Models;

namespace SnakesAndLadder.Domain
{
    public interface IBoardService
    {
        void CreateBoard(int boardSize);
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
    }
}
