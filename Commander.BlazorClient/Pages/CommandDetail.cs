using System;
using System.Threading.Tasks;
using Commander.BlazorClient.Models;
using Commander.BlazorClient.Services;
using Microsoft.AspNetCore.Components;

namespace Commander.BlazorClient.Pages
{
    public partial class CommandDetail
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public ICommandDataService CommandDataService { get; set; }

        public CommandData Command { get; set; } = new CommandData();

        protected async override Task OnInitializedAsync()
        {
            var commandId = Convert.ToInt32(Id);
            Command = await CommandDataService.GetCommandDetails(commandId);
        }
    }
}