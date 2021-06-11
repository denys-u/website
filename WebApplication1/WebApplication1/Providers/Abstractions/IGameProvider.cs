using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entyties;

namespace WebApplication1.Providers.Abstractions
{
    public interface IGameProvider
    {
        Task<string> CreateAsync(Game game);
        Task<bool> UpdateAsync(Game game);
        Task<bool> DeleteAsync(string id);
        Task<Game> GetByIdAsync(string id);
    }
}
