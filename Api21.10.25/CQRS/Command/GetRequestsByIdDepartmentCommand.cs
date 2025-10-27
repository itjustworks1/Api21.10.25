using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command
{
    public class GetRequestsByIdDepartmentCommand : IRequest<List<ApplicationDTO>>
    {
        public required int Id { get; set; }
        public class GetRequestsByIdDepartmentCommandHandler : IRequestHandler<GetRequestsByIdDepartmentCommand, List<ApplicationDTO>>
        {
            private readonly Api211025Context db;
            public GetRequestsByIdDepartmentCommandHandler(Api211025Context db)
            {
                this.db = db;
            }
            public async Task<List<ApplicationDTO>> HandleAsync(GetRequestsByIdDepartmentCommand request, CancellationToken ct = default)
            {
                return db.Applications.Where(s => s.DepartmentId == request.Id).Select(s => new ApplicationDTO() { 
                    ApplicantEmail = s.ApplicantEmail,
                    CreatedAt = s.CreatedAt,
                    DepartmentId = s.DepartmentId,
                    UpdatedAt = s.UpdatedAt,
                    EmployeeId = s.EmployeeId,
                    EndDate = s.EndDate,
                    Purpose = s.Purpose,
                    RejectionReason = s.RejectionReason,
                    StartDate = s.StartDate,
                    StatusId = s.StatusId,
                    ApplicationTypeId = s.ApplicationTypeId,
                    Id = s.Id,
                }).ToList();
            }
        }
    }
}