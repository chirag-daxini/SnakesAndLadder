using Microsoft.Extensions.Hosting;
using SnakesAndLadder.Domain;
using SnakesAndLadder.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SnakesAndLadder
{
    public class Startup : IHostedService
    {
        private readonly IBoardService _boardService;
        private readonly GameSettings _settings;
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;
        public Startup(IBoardService boardService, IPlayerService playerService, IGameService gameService, GameSettings gameSettings)
        {
            _boardService = boardService;
            _settings = gameSettings;
            _playerService = playerService;
            _gameService = gameService;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Welecome to Snakes & Ladder Game.");

            Console.WriteLine($"Intializing board with {_settings.BoardSize}");
            _boardService.CreateBoard(_settings.BoardSize);

            Console.WriteLine("Adding ladders on game board");
            for (int i = 0; i < _settings.Ladders.Length; i++)
            {
                var ladderConfig = _settings.Ladders[i];
                _boardService.AddLadder(ladderConfig);
            }

            Console.WriteLine("Adding snakes on game board");
            for (int i = 0; i < _settings.Snakes.Length; i++)
            {
                var snakeConfig = _settings.Snakes[i];
                _boardService.AddSnake(snakeConfig);
            }

            Console.WriteLine("Intializing Players");
            for (int i = 0; i < _settings.NoOfPlayers; i++)
            {
                Console.WriteLine($"Enter Player {i} Name : ");
                string name = Console.ReadLine();
                var player = new Player() { PlayerName = name };
                _playerService.AssignPlayers(player);
            }
            Console.WriteLine("=============================================================================");
            _gameService.StartGame();

            Console.Read();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Exiting from game");
        }
    }
}
