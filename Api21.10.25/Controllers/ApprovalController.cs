using Api21._10._25.CQRS.Command;
using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;

namespace Api21._10._25.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApprovalController : ControllerBase
    {
        private readonly Mediator mediator;
        [HttpGet("requests")]
        public async Task<ActionResult> GetRequestsByIdDepartment(int departmentId)
        {
            var command = new GetRequestsByIdDepartmentCommand() { Id = departmentId };
            var result = await mediator.SendAsync(command);
            return Ok();
        }
        [HttpPost("approve")]
        public async Task<ActionResult> Approve(Application application)
        {
            var command = new ApproveCommand() { Application = application };
            await mediator.SendAsync(command);
            return Ok();
        }
        [HttpPost("reject")]
        public async Task<ActionResult> Reject(Application application)
        {
            var command = new RejectCommand() { Application = application };
            await mediator.SendAsync(command);
            return Ok();
        }
    }
}
