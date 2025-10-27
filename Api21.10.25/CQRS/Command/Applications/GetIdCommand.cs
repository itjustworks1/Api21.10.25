using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command.Applications
{
    public class GetIdCommand : IRequest<ApplicationDTO>
    {
        public required int Id { get; set; }
        public class GetIdCommandHandler : IRequestHandler<GetIdCommand, ApplicationDTO>
        {
            private readonly Api211025Context db;
            public GetIdCommandHandler(Api211025Context db)
            {
                this.db = db;
                ApplicationType = db.ApplicationTypes.FirstOrDefault(s => s.Value == "personal");
            }
            private ApplicationType ApplicationType {  get; set; }
            public async Task<ApplicationDTO> HandleAsync(GetIdCommand request, CancellationToken ct = default)
            {
                Application application = db.Applications.FirstOrDefault(s => s.Id == request.Id);
                return new ApplicationDTO 
                { 
                    Id = application.Id,
                    ApplicantEmail = application.ApplicantEmail,
                    ApplicationTypeId = application.ApplicationTypeId,
                    CreatedAt = application.CreatedAt,
                    DepartmentId = application.DepartmentId,
                    EmployeeId = application.EmployeeId,
                    EndDate = application.EndDate,
                    Purpose = application.Purpose,
                    RejectionReason = application.RejectionReason,
                    StartDate = application.StartDate,
                    StatusId = application.StatusId,
                    UpdatedAt = application.UpdatedAt
                };
            }
        }
    }
}