namespace SnakesAndLadder.Models
{
    public class Player : Cell
    {
        public int PlayerNumber { get; set; }

        public string PlayerName { get; set; }

        public int CurrentCellPosition { get; set; } = 1;

        public bool IsTheWinner { get; set; } = false;

        public int FirstDice { get; set; } = 0;
        public bool IsFirstMove { get; set; } = true;
    }
}
