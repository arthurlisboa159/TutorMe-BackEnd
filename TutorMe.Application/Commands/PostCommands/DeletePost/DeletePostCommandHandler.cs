// using MediatR;
// using TutorMe.Core.Repositories;
//
// namespace TutorMe.Application.Commands.PostCommands.DeletePost;
//
// public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
// {
//     private readonly IPostRepository _postRepository;
//
//     public DeletePostCommandHandler(IPostRepository postRepository)
//     {
//         _postRepository = postRepository;
//     }
//     
//     public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
//     {
//         var post = await _postRepository.GetByIdAsync(request.Id);
//
//         if (post is not null) await _postRepository.RemoveAsync(post);
//
//         return Unit.Value;
//     }
// }