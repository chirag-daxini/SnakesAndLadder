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
        public Startup(IBoardService boardService, GameSettings gameSettings)
        {
            _boardService = boardService;
            _settings = gameSettings;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Welecome to Snakes & Ladder Game.");
            Console.WriteLine($"Creating Game board with {_settings.BoardSize}");
            _boardService.CreateBoard(_settings.BoardSize);

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
