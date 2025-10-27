using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api21._10._25.CQRS.Command.Applications
{
    public class GetPersonalCommand : IRequest<List<PersonalVisitorDTO>>
    {
        public required string Email { get; set; }
        public class GetPersonalCommandHandler : IRequestHandler<GetPersonalCommand, List<PersonalVisitorDTO>>
        {
            private readonly Api211025Context db;
            public GetPersonalCommandHandler(Api211025Context db)
            {
                this.db = db;
            }
            public async Task<List<PersonalVisitorDTO>> HandleAsync(GetPersonalCommand request, CancellationToken ct = default)
            {
                return db.PersonalVisitors.Where(s => s.Email == request.Email).Select(s => new PersonalVisitorDTO 
                { 
                    Email = s.Email,
                    ApplicationId = s.ApplicationId,
                    BirthDate = s.BirthDate,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Id = s.Id,
                    MiddleName = s.MiddleName,
                    Organization = s.Organization,
                    PassportNumber = s.PassportNumber,
                    PassportSeries = s.PassportSeries,
                    Phone = s.Phone
                }).ToList();
            }
        }
    }
}