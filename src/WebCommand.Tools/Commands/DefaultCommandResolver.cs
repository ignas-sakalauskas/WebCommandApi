using StructureMap;

namespace WebCommand.Tools.Commands
{
    public class DefaultCommandResolver : ICommandResolver
    {
        private readonly IContainer _container;

        public DefaultCommandResolver(IContainer container)
        {
            _container = container;
        }

        public TCommand ResolveCommand<TCommand>(ICommandContext context) where TCommand : ICommandBase
        {
            var command = _container.GetInstance<TCommand>();
            command.Context = context;

            return command;
        }
    }
}
