using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command
{
    public class GetGroupCommand : IRequest
    {
        public required ApplicationDTO Application { get; set; }
        public class GetGroupCommandHandler : IRequestHandler<GetGroupCommand, Unit>
        {
            private readonly Api211025Context db;
            public GetGroupCommandHandler(Api211025Context db)
            {
                this.db = db;
                ApplicationType = db.ApplicationTypes.FirstOrDefault(s => s.Value == "personal");
            }
            private ApplicationType ApplicationType {  get; set; }
            public async Task<Unit> HandleAsync(GetGroupCommand request, CancellationToken ct = default)
            {
                db.Applications.Add( new Application() { 
                    ApplicantEmail = request.Application.ApplicantEmail,
                    ApplicationType = ApplicationType,
                    ApplicationTypeId = ApplicationType.Id,
                    CreatedAt = request.Application.CreatedAt,
                    DepartmentId = request.Application.DepartmentId,
                    UpdatedAt = request.Application.UpdatedAt,
                    EmployeeId = request.Application.EmployeeId,
                    EndDate = request.Application.EndDate,
                    Purpose = request.Application.Purpose,
                    RejectionReason = request.Application.RejectionReason,
                    StartDate = request.Application.StartDate,
                    StatusId = request.Application.StatusId                    
                });
                db.SaveChanges();
                return Unit.Value;
            }
        }
    }
}