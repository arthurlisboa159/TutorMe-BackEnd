using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TutorMe.Application.Queries.SubscriptionQueries.CheckIfIsSubscribed;
using TutorMe.Core.Exceptions;

namespace TutorMe.API.Controllers;

[Route("api/subscription")]
public class SubscriptionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubscriptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{name}/isSubscribed")]
    public async Task<IActionResult> GetIfIsSubscribed(string name)
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

            var query = new CheckIfIsSubscribedQuery(name);
            
            var tokenS = jsonToken as JwtSecurityToken;
            var email = tokenS.Claims.First(claim => claim.Type == "email").Value;
            
            query.setUserEmail(email);
            
            var isSubscribed = await _mediator.Send(query);

            return Ok(isSubscribed);
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
}