// using MediatR;
// using TutorMe.Core.Repositories;
//
// namespace TutorMe.Application.Commands.Post.UpdatePost;
//
// public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Unit>
// {
//     private readonly IPostRepository _postRepository;
//
//     public UpdatePostCommandHandler(IPostRepository postRepository)
//     {
//         _postRepository = postRepository;
//     }
//     public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
//     {
//         var post = await _postRepository.GetByIdAsync(request.IdPost);
//         
//         // TODO: Testar essa questão do savechangesasync, se de fato não precisa fazer o update antes.
//         if (post is not null)
//         {
//             post.Update(request.Title, request.Content);
//             await _postRepository.Update(post);
//         }
//         
//         return Unit.Value;
//     }
// }