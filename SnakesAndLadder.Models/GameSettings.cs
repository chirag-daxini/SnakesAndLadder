namespace SnakesAndLadder.Models
{
    public class GameSettings
    {
        public int BoardSize { get; set; }
        public Ladder[] Ladders { get; set; }
        public Snake[] Snakes { get; set; }
        public int NoOfPlayers { get; set; }
        public int IntialToken { get; set; }
    }
}
