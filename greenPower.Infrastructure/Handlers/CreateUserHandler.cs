using greenPower.Infrastructure.Commands;
using greenPower.Infrastructure.Commands.Users;
using greenPower.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace greenPower.Infrastructure.Handlers
{
    class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task Handle(CreateUser command)
        {
            throw new NotImplementedException();
        }
    }
}
