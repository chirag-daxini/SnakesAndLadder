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
        public Startup(IBoardService boardService, IPlayerService playerService, GameSettings gameSettings)
        {
            _boardService = boardService;
            _settings = gameSettings;
            _playerService = playerService;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Welecome to Snakes & Ladder Game.");

            Console.WriteLine($"Intializing Game board with {_settings.BoardSize}");
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


        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {

        }
    }
}
