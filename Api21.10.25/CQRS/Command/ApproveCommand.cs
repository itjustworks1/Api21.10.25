using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command
{
    public class ApproveCommand : IRequest
    {
        public required Application Application { get; set; }
        public class ApproveCommandHandler : IRequestHandler<ApproveCommand, Unit>
        {
            private readonly Api211025Context db;
            public ApproveCommandHandler(Api211025Context db)
            {
                this.db = db;
            }
            public async Task<Unit> HandleAsync(ApproveCommand request, CancellationToken ct = default)
            {
                Status status = db.Statuses.FirstOrDefault(s => s.Value == "approved");
                request.Application.StatusId = status.Id;
                request.Application.Status = status;
                db.SaveChanges();
                return Unit.Value;
            }
        }
    }
}