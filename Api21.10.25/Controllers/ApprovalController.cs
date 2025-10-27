using Api21._10._25.CQRS.Command.Approval;
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
        public ApprovalController(MyMediator.Types.Mediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("requests?departmentId={id}")]
        public async Task<ActionResult<ApprovalController>> GetRequestsByIdDepartment(int id)
        {
            var command = new GetRequestsByIdDepartmentCommand() { IdDepartment = id };
            await mediator.SendAsync(command);
            return Ok();
        }
        [HttpPost("approve")]
        public async void Approve(Application application)
        {
            var command = new ApproveCommand() { Application = application };
            await mediator.SendAsync(command);
            return;
        }
        [HttpPost("reject")]
        public async void Reject(Application application)
        {
            var command = new RejectCommand() { Application = application };
            await mediator.SendAsync(command);
            return;
        }
    }
}
