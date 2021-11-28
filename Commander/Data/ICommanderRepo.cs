using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();

        Command GetCommandById(int id);

        bool AddCommand(Command command);

        bool DeleteCommand(int id);

        // Update entity or add if it does not exist
        bool UpsertCommand(Command command);
    }
}