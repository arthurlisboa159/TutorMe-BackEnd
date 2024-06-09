// using MediatR;
// using TutorMe.Core.Repositories;
//
// namespace TutorMe.Application.Commands.PostCommands.OpenPost;
//
// public class OpenPostCommandHandler : IRequestHandler<OpenPostCommand, Unit>
// {
//     private readonly IPostRepository _postRepository;
//
//     public OpenPostCommandHandler(IPostRepository postRepository)
//     {
//         _postRepository = postRepository;
//     }
//     
//     public async Task<Unit> Handle(OpenPostCommand request, CancellationToken cancellationToken)
//     {
//         var post = await _postRepository.GetByIdAsync(request.Id);
//
//         if (post is not null)
//         {
//             post.Open();
//             await _postRepository.Update(post);
//         }
//         
//         return Unit.Value;
//     }
// }