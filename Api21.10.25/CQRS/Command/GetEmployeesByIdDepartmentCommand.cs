using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command
{
    public class GetEmployeesByIdDepartmentCommand : IRequest<List<EmployeeDTO>>
    {
        public required int Id { get; set; }
        public class ApproveCommandHandler : IRequestHandler<GetEmployeesByIdDepartmentCommand, List<EmployeeDTO>>
        {
            private readonly Api211025Context db;
            public ApproveCommandHandler(Api211025Context db)
            {
                this.db = db;
            }
            public async Task<List<EmployeeDTO>> HandleAsync(GetEmployeesByIdDepartmentCommand request, CancellationToken ct = default)
            {
                return db.Employees.Where(s => s.DepartmentId == request.Id).Select(s => new EmployeeDTO()
                {
                    Id = s.Id,
                    DepartmentId = s.DepartmentId,
                    FullName = s.FullName
                }).ToList();
            }
        }
    }
}