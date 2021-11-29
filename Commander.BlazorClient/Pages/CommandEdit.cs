using System;
using System.Threading.Tasks;
using Commander.BlazorClient.Models;
using Commander.BlazorClient.Services;
using Microsoft.AspNetCore.Components;

namespace Commander.BlazorClient.Pages
{
    public partial class CommandEdit
    {
        // State Management
        protected string Message = string.Empty;
        protected bool Saved;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ICommandDataService CommandDataService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public CommandData Command { get; set; } = new CommandData();

        protected async override Task OnInitializedAsync()
        {
            Saved = false;

            if (!String.IsNullOrEmpty(Id))
            {
                var commandId = Convert.ToInt32(Id);
                Command = await CommandDataService.GetCommandDetails(commandId);
            }
        }

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(Id)) // We need to add the command
            {
                var result = await CommandDataService.AddCommand(Command);

                if (result != null)
                {
                    Saved = true;
                    Message = "Command has been added";
                }
                else
                {
                    Message = "Something went wrong";
                }
            }
            else
            {
                await CommandDataService.UpdateCommand(Command);
                Saved = true;
                Message = "Command has been updated";
            }
        }

        protected void HandleInvalidRequest()
        {
            Message = "Failed to submit form";
        }

        protected void GoToOverview()
        {
            NavigationManager.NavigateTo("/CommandOverview");
        }

        protected async Task DeleteCommand()
        {
            if (!String.IsNullOrEmpty(Id))
            {
                var commandId = Convert.ToInt32(Id);
                await CommandDataService.DeleteCommand(commandId);

                NavigationManager.NavigateTo("/CommandOverview");
            }

            Message = "Something went wrong, unable to delete";
        }
    }
}