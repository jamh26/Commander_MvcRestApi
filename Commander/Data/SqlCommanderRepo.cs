using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public Command AddCommand(Command command)
        {
            var result = _context.Add(command);
            _context.SaveChanges();

            return command;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public Command UpsertCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        bool ICommanderRepo.DeleteCommand(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}