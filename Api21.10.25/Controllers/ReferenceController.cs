using Api21._10._25.CQRS.Command;
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
        [HttpGet("departments")]
        public async Task<ActionResult<List<DepartmentDTO>>> GetDepartments()
        {
            var command = new GetDepartmentsCommand() { };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }
        [HttpGet("departments/{id}/employees")]
        public async Task<ActionResult<List<EmployeeDTO>>> GetEmployeesByIdDepartment(int id)
        {
            var command = new GetEmployeesByIdDepartmentCommand() { Id = id };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }
    }
}
