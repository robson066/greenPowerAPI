using greenPower.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace greenPower.API.Controllers
{
    [Route("[controller]")]
    public abstract class APIControllerBase : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;

        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
                                 Guid.Parse(User.Identity.Name) :
                                 Guid.Empty;

        protected APIControllerBase(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command is IAuthenticatedCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = UserId;
            }

            await CommandDispatcher.Dispatch(command);
        }
    }
}
