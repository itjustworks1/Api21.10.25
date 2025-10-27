using Api21._10._25.CQRS.Command.Reference;
using Api21._10._25.CQRS.DTO;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;

namespace Api21._10._25.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceController : ControllerBase
    {
        private readonly Mediator mediator;
        public ReferenceController(MyMediator.Types.Mediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("departments")]
        public async Task<ActionResult<DepartmentDTO>> GetDepartments()
        {
            var command = new GetDepartmentsCommand() {};
            await mediator.SendAsync(command);
            return Ok();
        }
        [HttpGet("departments/{id}/employees")]
        public async Task<ActionResult<DepartmentDTO>> GetEmployeesByIdDepartment(int id)
        {
            var command = new GetEmployeesByIdDepartmentCommand() { Id = id };
            await mediator.SendAsync(command);
            return Ok();
        }
    }
}
