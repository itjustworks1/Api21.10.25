using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command.Reference
{
    public class GetEmployeesByIdDepartmentCommand : IRequest<List<DepartmentDTO>>
    {
        public required int Id { get; set; }
        public class ApproveCommandHandler : IRequestHandler<GetEmployeesByIdDepartmentCommand, List<DepartmentDTO>>
        {
            private readonly Api211025Context db;
            public ApproveCommandHandler(Api211025Context db)
            {
                this.db = db;
            }
            public async Task<List<DepartmentDTO>> HandleAsync(GetEmployeesByIdDepartmentCommand request, CancellationToken ct = default)
            {
                return db.Departments.Where(s => s.Id == request.Id).Select(s => new DepartmentDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Code = s.Name,
                }).ToList();
                
            }
        }
    }
}