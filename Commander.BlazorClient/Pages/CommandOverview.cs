using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.BlazorClient.Models;
using Commander.BlazorClient.Services;
using Microsoft.AspNetCore.Components;

namespace Commander.BlazorClient.Pages
{
    public partial class CommandOverview
    {
        public IEnumerable<CommandData> Commands { get; set; }

        [Inject]
        public ICommandDataService CommandDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Commands = (await CommandDataService.GetAllCommands()).ToList();
        }
    }
}