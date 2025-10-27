using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command
{
    public class GetGroupCommand : IRequest<List<RApplicationDTO>>
    {
        public required string Email { get; set; }
        public class GetGroupCommandHandler : IRequestHandler<GetGroupCommand, List<RApplicationDTO>>
        {
            private readonly Api211025Context db;
            public GetGroupCommandHandler(Api211025Context db)
            {
                this.db = db;
            }
            public async Task<List<RApplicationDTO>> HandleAsync(GetGroupCommand request, CancellationToken ct = default)
            {
                return db.GroupApplicationContacts.Where(s => s.ContactEmail == request.Email).Select(s => new RApplicationDTO
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