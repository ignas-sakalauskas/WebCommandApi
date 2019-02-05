using Microsoft.AspNetCore.Mvc;
using WebCommand.Logic.Commands.UserPersistence;
using WebCommand.Tools.Commands;

namespace WebCommand.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ExtendedControllerBase
    {
        public ValuesController(ICommandResolver commandResolver) 
            : base(commandResolver)
        {
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserPersistenceModel model)
        {
            var success = GetCommand<PersistUserCommand>().Execute(model);

            return success ? 
                Ok() : 
                new StatusCodeResult(500);
        }
    }
}
