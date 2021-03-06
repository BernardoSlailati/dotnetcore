using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
        }

        public void DeleteAllCommands()
        {
        }

        public void DeleteCommand(Command cmd)
        {
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command> 
            {
                new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & pan"},
                new Command{Id=1, HowTo="Cut bread", Line="Get a knife", Platform="Knife & chopping board"},
                new Command{Id=2, HowTo="Make cup of tea", Line="Place teabag in cup", Platform="Kettle & cup"}
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Boil an Egg", Line="Boil Water", Platform="Kettle & Pan"};
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void UpdateCommand(Command cmd)
        {
        }
    }
}