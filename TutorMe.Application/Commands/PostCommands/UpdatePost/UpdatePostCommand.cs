using System.Text.Json.Serialization;
using MediatR;

namespace TutorMe.Application.Commands.Post.UpdatePost;

public class UpdatePostCommand : IRequest<Unit>
{
    public string Title { get; set; }
    public string Content { get; set; }
  
    [JsonIgnore]
    public int IdPost { get; set; }
}




