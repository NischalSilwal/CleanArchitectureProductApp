using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto loginDto)
        {
            var token = await _mediator.Send(new LoginCommand(loginDto));
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
