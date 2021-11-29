using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.BlazorClient.Models;

namespace Commander.BlazorClient.Services
{
    public interface ICommandDataService
    {
        Task<IEnumerable<CommandData>> GetAllCommands();
        Task<CommandData> GetCommandDetails(int id);
    }
}