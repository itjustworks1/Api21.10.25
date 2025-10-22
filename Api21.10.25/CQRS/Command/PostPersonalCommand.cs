using MyMediator.Interfaces;

namespace Api21._10._25.CQRS.Command
{
    public class PostPersonalCommand : IRequest<IEnumerable<int>>
    {
        public class PostPersonalCommandHandler : IRequestHandler<PostPersonalCommand, IEnumerable<int>>
        {
            public Task<IEnumerable<int>> HandleAsync(PostPersonalCommand request, CancellationToken ct = default)
            {
                throw new NotImplementedException();
            }
        }
    }
}