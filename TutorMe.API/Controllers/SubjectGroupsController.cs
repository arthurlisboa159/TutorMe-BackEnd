using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorMe.Application.Commands.SubjectGroupCommands.CreateSubjectGroup;
using TutorMe.Application.Commands.SubjectGroupCommands.SubscribeSubjectGroup;
using TutorMe.Application.Queries.SubjectGroupQueries.GetSubjectGroupByName;
using TutorMe.Application.Queries.SubjectGroupQueries.SearchGroup;
using TutorMe.Core.Exceptions;

namespace TutorMe.API.Controllers;

[Route("api/subject-group")]
[Authorize]
public class SubjectGroupsController  : ControllerBase
{
    private readonly IMediator _mediator;
    
    public SubjectGroupsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        try
        {
            var token = Request.Headers["Authorization"].ToString();

            if (token.Contains("Bearer"))
                token = token.Substring("Bearer ".Length);
            
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);

            if (jsonToken.ValidTo < DateTime.Now)
            {
                return Unauthorized();
            }

            var command = new GetSubjectGroupByNameQuery(name);

            var subjectGroup = await _mediator.Send(command);

            return Ok(subjectGroup);
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
            
        }
        catch
        {
            return BadRequest();
        }
    }
    
    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> Post([FromBody] CreateSubjectGroupCommand command)
    {
        try
        {
            if (command.Name.Length > 70)
                return UnprocessableEntity();

            var token = Request.Headers["Authorization"].ToString();
            
            if (token.Contains("Bearer"))
                token = token.Substring("Bearer ".Length);
            
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);

            if (jsonToken.ValidTo < DateTime.Now)
            {
                return Unauthorized();
            }

            var tokenS = jsonToken as JwtSecurityToken;
            var email = tokenS.Claims.First(claim => claim.Type == "email").Value;

            command.SetEmail(email);

            var id = await _mediator.Send(command);

            return Ok(command);
        }
        catch (EntityAlreadyExistsException)
        {
            return Conflict();
        }
        catch
        {
            return BadRequest();
        }
    }
    
    
    [HttpPost("{name}/subscribe")]
    public async Task<IActionResult> Post(string name)
    {
        try
        {
            var token = Request.Headers["Authorization"].ToString();
            
            if (token.Contains("Bearer"))
                token = token.Substring("Bearer ".Length);
            
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);

            if (jsonToken.ValidTo < DateTime.Now)
            {
                return Unauthorized();
            }

            var tokenS = jsonToken as JwtSecurityToken;
            var email = tokenS.Claims.First(claim => claim.Type == "email").Value;

            var command = new SubscribeSubjectGroupCommand(name, email);
            
            await _mediator.Send(command);

            return Ok();
        }
        catch (EntityAlreadyExistsException)
        {
            return Conflict();
        }
        catch
        {
            return BadRequest();
        }
    }
    

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] SearchGroupQuery query)
    {

        var results = await _mediator.Send(query);
        
        return Ok(results);
    }
}