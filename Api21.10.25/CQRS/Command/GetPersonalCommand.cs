using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command
{
    public class GetPersonalCommand : IRequest<List<RApplicationDTO>>
    {
        public required string Email { get; set; }
        public class GetPersonalCommandHandler : IRequestHandler<GetPersonalCommand, List<RApplicationDTO>>
        {
            private readonly Api211025Context db;
            public GetPersonalCommandHandler(Api211025Context db)
            {
                this.db = db;
            }
            public async Task<List<RApplicationDTO>> HandleAsync(GetPersonalCommand request, CancellationToken ct = default)
            {
                return db.PersonalVisitors.Where(s => s.Email == request.Email).Select(s => new RApplicationDTO
                { 
                    IdApplicationType = s.Application.ApplicationTypeId,
                    IdDepartment = s.Application.DepartmentId,
                    IdStatus = s.Application.StatusId,
                    //Date = ,
                    //ReasonRefusal = 
                }).ToList();
            }
        }
    }
}