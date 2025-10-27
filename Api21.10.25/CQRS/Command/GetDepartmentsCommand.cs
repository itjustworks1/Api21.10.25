using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command
{
    public class GetDepartmentsCommand : IRequest<List<DepartmentDTO>>
    {
        public class GetDepartmentsCommandHandler : IRequestHandler<GetDepartmentsCommand, List<DepartmentDTO>>
        {
            private readonly Api211025Context db;
            public GetDepartmentsCommandHandler(Api211025Context db)
            {
                this.db = db;
            }
            public async Task<List<DepartmentDTO>> HandleAsync(GetDepartmentsCommand request, CancellationToken ct = default)
            {
                return db.Departments.Select(s => new DepartmentDTO() 
                { 
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                }).ToList();
            }
        }
    }
}