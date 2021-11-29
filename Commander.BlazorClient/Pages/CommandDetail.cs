using System.Threading.Tasks;
using Commander.BlazorClient.Models;
using Microsoft.AspNetCore.Components;

namespace Commander.BlazorClient.Pages
{
    public partial class CommandDetail
    {
        [Parameter]
        public string Id { get; set; }

        public CommandData Command { get; set; } = new CommandData();

        private void InitializeCommand()
        {
            var c1 = new CommandData
            {
                Id = 1,
                HowTo = "test",
                Line = "test",
                Platform = "test"
            };

            Command = c1;


        }

        protected override Task OnInitializedAsync()
        {
            InitializeCommand();
            return base.OnInitializedAsync();
        }
    }
}