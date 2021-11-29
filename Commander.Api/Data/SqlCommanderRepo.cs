using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Api.Models;

namespace Commander.Api.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public bool AddCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            try
            {
                var result = _context.Add(command);
                return SaveChanges();
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool UpsertCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            try
            {
                var result = _context.Remove(command);
                return SaveChanges();
            }
            catch
            {
                return false;
            }
        }

        public void UpdateCommand(Command command)
        {

        }

        public bool SaveChanges()
        {
            try
            {
                return (_context.SaveChanges() >= 0);
            }
            catch
            {
                return false;
            }
        }
    }
}