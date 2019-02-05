using Microsoft.AspNetCore.Mvc;
using WebCommand.Tools.Commands;

namespace WebCommand.Api.Controllers
{
    public abstract class ExtendedControllerBase : ControllerBase, ICommandContext
    {
        private readonly ICommandResolver _commandResolver;

        protected ExtendedControllerBase(ICommandResolver commandResolver)
        {
            _commandResolver = commandResolver;
        }

        protected TCommand GetCommand<TCommand>() where TCommand : ICommandBase
        {
            return _commandResolver.ResolveCommand<TCommand>(this);
        }
    }
}