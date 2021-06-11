using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entyties;
using WebApplication1.Providers.Abstractions;

namespace WebApplication1.Providers
{
    public class GameProvider : IGameProvider
    {
        private readonly ILogger<GameProvider> _logger;
        private readonly List<Game> _games = new List<Game>();

        public GameProvider(
            ILogger<GameProvider> logger)
        {
            _logger = logger;
        }

        public async Task<string> CreateAsync(Game game)
        {
            _logger.LogInformation($"Started {nameof(CreateAsync)}");
            return await Task.Run(() =>
            {
                var id = Guid.NewGuid().ToString();
                _games.Add(new Game()
                {
                    Id = game.Id,
                    Name = game.Name,
                    Price = game.Price,
                    Rating = game.Rating,
                    Genre = game.Genre,
                    Developer = game.Developer,
                    Release = game.Release
                });

                return id;
            });

        }

        public async Task<bool> DeleteAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(DeleteAsync)}");
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            return await Task.Run(() =>
            {
                var item = _games.FirstOrDefault(f => f.Id == id);
                if (item == null)
                {
                    return false;
                }

                return _games.Remove(item);
            });
        }

        public async Task<Game> GetByIdAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(GetByIdAsync)}");
            return await Task.Run(() =>
            {
                return _games.FirstOrDefault(f => f.Id == id);
            });

        }

        public async Task<bool> UpdateAsync(Game game)
        {
            _logger.LogInformation($"Started {nameof(UpdateAsync)}");

            return await Task.Run(() =>
            {
                var item = _games.FirstOrDefault(f => f.Id == game.Id);
                if (item == null)
                {
                    return false;
                }

                item.Name = game.Name;
                item.Price = game.Price;
                item.Rating = game.Rating;
                item.Genre = game.Genre;
                item.Developer = game.Developer;
                item.Release = game.Release;

                return true;
            });

        }
    }
}
