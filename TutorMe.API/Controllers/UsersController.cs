using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorMe.Application.Commands.UserCommands.CreateUser;
using TutorMe.Application.Commands.UserCommands.LoginUser;

namespace TutorMe.API.Controllers;

[Route("api/users")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        var id = await _mediator.Send(command);
        
        return Ok();
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var loginUserViewModel = await _mediator.Send(command);

        if (loginUserViewModel is null)
        {
            return BadRequest();
        }
        
        return Ok(loginUserViewModel);
    }

    [HttpGet("isAuthenticated")]
    [Authorize]
    public Task<IActionResult> IsAuthenticated()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}