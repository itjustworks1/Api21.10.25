using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command.Applications
{
    public class GetGroupCommand : IRequest<List<RaApplicationDTO>>
    {
        public required string Email { get; set; }
        public class GetGroupCommandHandler : IRequestHandler<GetGroupCommand, List<RaApplicationDTO>>
        {
            private readonly Api211025Context db;
            public GetGroupCommandHandler(Api211025Context db)
            {
                this.db = db;
            }
            public async Task<List<RaApplicationDTO>> HandleAsync(GetGroupCommand request, CancellationToken ct = default)
            {
                return db.PersonalVisitors.Where(s => s.Email == request.Email).Select(s => new RaApplicationDTO
                {
                    IdApplicationTypeDTO = s.Application.ApplicationTypeId,
                    IdDepartmentDTO = s.Application.DepartmentId,
                    IdStatus = s.Application.StatusId,
                    Date = s.Application.CreatedAt,
                    Reason = s.Application.RejectionReason,
                }).ToList();
            }
        }
    }
}