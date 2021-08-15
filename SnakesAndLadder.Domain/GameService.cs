using SnakesAndLadder.Models;
using System;
using System.Linq;

namespace SnakesAndLadder.Domain
{
    public interface IGameService
    {
        void StartGame();
    }
    public class GameService : IGameService
    {
        private readonly IBoardService _boardService;
        private readonly IPlayerService _playerService;
        private readonly ITokenService _tokenService;
        private readonly GameSettings _gameSettings;
        Player currentPlayer;
        public GameService(IBoardService boardService, IPlayerService playerService, ITokenService tokenService, GameSettings gameSettings)
        {
            _boardService = boardService;
            _playerService = playerService;
            _tokenService = tokenService;
            _gameSettings = gameSettings;
        }
        public void StartGame()
        {
            currentPlayer = _playerService.Players.First();

            while (currentPlayer.CurrentCellPosition != _boardService.Board.Length)
            {
                var nextToken = _tokenService.GetNextToken();

                if (currentPlayer.IsFirstMove && nextToken != 1)
                {
                    Console.WriteLine($"{currentPlayer.PlayerName} can't move untill intial token is 1");
                    currentPlayer = NextChance(currentPlayer);
                }
                else
                {
                    UpdatePosition(currentPlayer, nextToken);
                    currentPlayer.IsFirstMove = false;
                    currentPlayer = NextChance(currentPlayer);
                }

            }

            foreach (Player p in _playerService.Players)
                Console.WriteLine($"{p.PlayerName} is at {p.CurrentCellPosition}");

            Console.WriteLine($"Player {currentPlayer.PlayerName} Won !!!");
        }

        private Player NextChance(Player currPlayer)
        {
            Player nextPlayer;

            if (currPlayer.PlayerNumber < _gameSettings.NoOfPlayers)
                nextPlayer = _playerService.Players.Skip(currPlayer.PlayerNumber).First();
            else
                nextPlayer = _playerService.Players.First();

            return nextPlayer;
        }

        private void UpdatePosition(Player currPlayer, int diceNumber)
        {
            int moveLocation = currPlayer.CurrentCellPosition;
            if ((moveLocation + diceNumber) <= _boardService.Board.Length)
            {
                moveLocation = moveLocation + diceNumber;
                Console.WriteLine($"{currPlayer.PlayerName}: moved to {moveLocation}");
            }
            else
            {
                Console.WriteLine($"{currPlayer.PlayerName}: stays at {moveLocation}");
            }

            while (_boardService.Board[moveLocation - 1].GetType() == typeof(Snake) || _boardService.Board[moveLocation - 1].GetType() == typeof(Ladder))
            {
                if (_boardService.Board[moveLocation - 1].GetType() == typeof(Snake))
                {
                    moveLocation = (_boardService.Board[moveLocation - 1] as Snake).PenaltyCell;
                    Console.WriteLine($"{currPlayer.PlayerName}: snake bite moving to {moveLocation}");
                }
                if (_boardService.Board[moveLocation - 1].GetType() == typeof(Ladder))
                {
                    moveLocation = (_boardService.Board[moveLocation - 1] as Ladder).AdvantageCell;
                    Console.WriteLine($"{currPlayer.PlayerName}: found ladder moving to {moveLocation}");
                }
            }
            currPlayer.CurrentCellPosition = moveLocation;

            if (currPlayer.CurrentCellPosition == _boardService.Board.Length)
                currPlayer.IsTheWinner = true;
        }
    }
}
