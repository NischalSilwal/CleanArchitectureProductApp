using CleanArchitectureApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public UserDto loginDto { get; }

        public LoginCommand(UserDto userDto)
        {
            loginDto = userDto;
        }
    }
}
