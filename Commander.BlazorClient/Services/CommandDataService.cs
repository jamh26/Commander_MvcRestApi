using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public async Task<CommandData> AddCommand(CommandData command)
        {
            try
            {
                var commandJson = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/commands", commandJson);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<CommandData>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task DeleteCommand(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/commands/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        public async Task UpdateCommand(CommandData command)
        {
            try
            {
                var commandJson = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json");

                var url = $"api/commands/{command.Id}";

                var response = await _httpClient.PutAsync(url, commandJson);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}