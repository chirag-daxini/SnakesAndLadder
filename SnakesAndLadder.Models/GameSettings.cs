namespace SnakesAndLadder.Models
{
    public class GameSettings
    {
        public int BoardSize { get; set; }
        public Ladder[] Ladders { get; set; }

        public Snake[] Snakes { get; set; }
    }
}
