// using MediatR;
// using TutorMe.Core.Repositories;
//
// namespace TutorMe.Application.Commands.PostCommands.ClosePost;
//
// public class ClosePostCommandHandler : IRequestHandler<ClosePostCommand, Unit>
// {
//     private readonly IPostRepository _postRepository;
//
//     public ClosePostCommandHandler(IPostRepository postRepository)
//     {
//         _postRepository = postRepository;
//     }
//     public async Task<Unit> Handle(ClosePostCommand request, CancellationToken cancellationToken)
//     {
//         var post = await _postRepository.GetByIdAsync(request.Id);
//         
//         if (post is not null)
//         {
//             post.Close();
//             await _postRepository.Update(post);
//         }
//         
//         return Unit.Value;
//     }
// }