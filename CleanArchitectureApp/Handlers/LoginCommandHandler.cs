using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Commands;
using CleanArchitectureApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenHelper _jwtTokenHelper;
        public LoginCommandHandler(IUserService userService, IJwtTokenHelper jwtTokenHelper)
        {
            _userService = userService;
            _jwtTokenHelper = jwtTokenHelper;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.Authenticate(request.loginDto.Username, request.loginDto.Password);
            if (user == null)
            {
                return null; // Unauthorized
            }

            return _jwtTokenHelper.GenerateToken(user);
        }
    }
}
