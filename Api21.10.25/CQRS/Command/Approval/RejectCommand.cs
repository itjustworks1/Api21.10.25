using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command.Approval
{
    public class RejectCommand : IRequest
    {
        public required Application Application { get; set; }
        public class RejectCommandHandler : IRequestHandler<RejectCommand, Unit>
        {
            private readonly Api211025Context db;
            public RejectCommandHandler(Api211025Context db)
            {
                this.db = db;
            }
            public async Task<Unit> HandleAsync(RejectCommand request, CancellationToken ct = default)
            {
                Status status = db.Statuses.FirstOrDefault(s => s.Value == "rejected");
                request.Application.StatusId = status.Id;
                request.Application.Status = status;
                db.SaveChanges();
                return Unit.Value;
            }
        }
    }
}