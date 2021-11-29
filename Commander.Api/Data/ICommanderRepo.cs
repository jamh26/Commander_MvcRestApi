using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Api.Models;

namespace Commander.Api.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();

        Command GetCommandById(int id);

        bool AddCommand(Command command);

        bool DeleteCommand(Command command);

        // Update entity or add if it does not exist
        bool UpsertCommand(Command command);

        void UpdateCommand(Command command);
    }
}