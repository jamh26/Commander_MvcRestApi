using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.BlazorClient.Models;

namespace Commander.BlazorClient.Pages
{
    public partial class CommandOverview
    {
        public IEnumerable<CommandData> Commands { get; set; }

        private void InitializeCommands()
        {
            var c1 = new CommandData
            {
                Id = 1,
                HowTo = "test",
                Line = "test",
                Platform = "test"
            };
            var c2 = new CommandData
            {
                Id = 2,
                HowTo = "test2",
                Line = "test2",
                Platform = "test2"
            };

            Commands = new List<CommandData> { c1, c2 };
        }

        protected override Task OnInitializedAsync()
        {
            InitializeCommands();
            return base.OnInitializedAsync();
        }
    }
}