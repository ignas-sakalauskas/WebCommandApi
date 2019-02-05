using StructureMap;
using WebCommand.Tools.Commands;

namespace WebCommand.Logic
{
    public class CommandsRegistry : Registry
    {
        public CommandsRegistry()
        {
            Scan(s =>
            {
                s.AssemblyContainingType<ICommand>();
                s.AddAllTypesOf(typeof(ICommand));
                s.ConnectImplementationsToTypesClosing(typeof(ICommand<>));
                s.ConnectImplementationsToTypesClosing(typeof(ICommand<,>));
            });

            For<ICommandResolver>()
                .Use<DefaultCommandResolver>();
        }
    }
}
