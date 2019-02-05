using Serilog;
using System;
using System.IO;
using WebCommand.Tools.Commands;

namespace WebCommand.Logic.Commands.UserPersistence
{
    public class PersistUserCommand : CommandBase, ICommand<UserPersistenceModel, bool>
    {
        private readonly ILogger _logger;

        public PersistUserCommand(ILogger logger)
        {
            _logger = logger;
        }

        public bool Execute(UserPersistenceModel request)
        {
            try
            {
                var line = $"{request.Id}|{request.Name}{Environment.NewLine}";
                File.AppendAllText("some_storage.txt", line);

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to persist in the file.", ex);
                return false;
            }
        }
    }
}
