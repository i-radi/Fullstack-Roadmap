using Commander.Data.DbContext;
using Commander.Models;

namespace Commander.Data.Repo
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
            => _context.Commands.ToList();

        public Command GetCommandById(int id)
            => _context.Commands.FirstOrDefault(p => p.Id == id);

        public bool SaveChanges()
            => _context.SaveChanges() >= 0;

        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }
    }
}