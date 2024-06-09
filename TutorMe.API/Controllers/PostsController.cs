using System.IdentityModel.Tokens.Jwt;
using System.Web;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorMe.Application.Commands.PostCommands.AddComment;
using TutorMe.Application.Commands.PostCommands.CreatePost;
using TutorMe.Application.Queries.PostQueries.GetComments;
using TutorMe.Application.Queries.PostQueries.GetPosts;
using TutorMe.Core.Exceptions;

namespace TutorMe.API.Controllers;

[Route("api/posts")]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get([FromQuery] GetPostsQuery query)
    {
        var posts = await _mediator.Send(query);
        
        return Ok(posts);
    }

    [HttpGet("{id}/comments")]
    public async Task<IActionResult> GetComments(Guid id)
    {
        var query = new GetCommentsQuery(id);
        
        var comments = await _mediator.Send(query);

        return Ok(comments);
    }

    [HttpPost("comment")]
    public async Task<IActionResult> AddComment([FromBody] AddCommentCommand command)
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
        
        command.setUserEmail(email);
        
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(AddComment), new {id = result.Id}, result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
    {
        try
        {
            var token = Request.Headers["Authorization"].ToString();
            
            if (token.Contains("Bearer"))
                token = token.Substring("Bearer ".Length);
            
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            
            var tokenS = jsonToken as JwtSecurityToken;
            var email = tokenS.Claims.First(claim => claim.Type == "email").Value;


            command.SubjectGroupName = HttpUtility.UrlDecode(command.SubjectGroupName);
            command.SetEmail(email);
            
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
}