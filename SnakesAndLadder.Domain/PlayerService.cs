using SnakesAndLadder.Models;
using System.Collections.Generic;

namespace SnakesAndLadder.Domain
{
    public interface IPlayerService
    {
        void AssignPlayers(Player player);
        List<Player> Players { get; set; }
    }
    public class PlayerService : IPlayerService
    {
        public List<Player> Players { get; set; } = new List<Player>();
        public int TotalPlayers => Players != null ? Players.Count : 0;

        public PlayerService()
        {

        }
        public void AssignPlayers(Player player)
        {
            if (player != null)
            {
                player.PlayerNumber = TotalPlayers + 1;
                Players.Add(player);
            }
        }
    }
}
