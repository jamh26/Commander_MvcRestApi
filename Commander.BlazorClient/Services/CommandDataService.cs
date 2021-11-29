using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Commander.BlazorClient.Models;

namespace Commander.BlazorClient.Services
{
    public class CommandDataService : ICommandDataService
    {
        private readonly HttpClient _httpClient;

        public CommandDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CommandData>> GetAllCommands()
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/commands");
            return await JsonSerializer.DeserializeAsync<IEnumerable<CommandData>>
                (apiResponse, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public async Task<CommandData> GetCommandDetails(int id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/commands/{id}");
            return await JsonSerializer.DeserializeAsync<CommandData>
                (apiResponse, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}