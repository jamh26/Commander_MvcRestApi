using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command
                {
                    Id = 0,
                    HowTo = "boil an egg",
                    Line = "Boil water",
                    Platform = "kettle & pan"
                },
                new Command
                {
                    Id = 1,
                    HowTo = "boil  egg",
                    Line = "Boil water",
                    Platform = "kettle & pan"
                },
                new Command
                {
                    Id = 2,
                    HowTo = "boil an",
                    Line = "Boil water",
                    Platform = "kettle & pan"
                }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command
            {
                Id = 0,
                HowTo = "boil an egg",
                Line = "Boil water",
                Platform = "kettle & pan"
            };
        }
    }
}