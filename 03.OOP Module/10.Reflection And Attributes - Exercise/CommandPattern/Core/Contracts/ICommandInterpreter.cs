using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string args);
    }
}
