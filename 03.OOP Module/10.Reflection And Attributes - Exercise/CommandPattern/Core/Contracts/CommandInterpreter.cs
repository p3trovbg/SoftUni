using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            
            string[] info = args.Split();
            string commandName = info[0] + "Command";
           
            var @params = info.Skip(1).ToArray();
            var typeCommand = Assembly.GetCallingAssembly().GetTypes().Where(x => x.Name == commandName).FirstOrDefault();
            if (typeCommand == null)
            {
                throw new ArgumentException("Invalid input!");
            }

            ICommand command = (ICommand)Activator.CreateInstance(typeCommand);
            string result = command.Execute(@params);
            return result;

        }
    }
}
