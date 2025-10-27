using Api21._10._25.CQRS.Command;
using Api21._10._25.CQRS.Command.Applications;
using Api21._10._25.CQRS.DTO;
using Api21._10._25.DB;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using static System.Net.Mime.MediaTypeNames;

namespace Api21._10._25.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly Mediator mediator;
        public ApplicationsController(MyMediator.Types.Mediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("personal")]
        public async Task<ActionResult> PostPersonal(ApplicationDTO application)
        {
            var command = new PostPersonalCommand() { Application = application};
            await mediator.SendAsync(command);
            return Ok();
        }
        [HttpPost("group")]
        public async Task<ActionResult> PostGroup(ApplicationDTO application)
        {
            var command = new PostGroupCommand() { Application = application };
            await mediator.SendAsync(command);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationDTO>> GetId(int id)
        {
            var command = new GetIdCommand() { Id = id };
            await mediator.SendAsync(command);
            return Ok();
        }
        [HttpGet("personal/{email}")]
        public async Task<ActionResult> GetPersonal(string email)
        {
            var command = new GetPersonalCommand() { Email = email };
            await mediator.SendAsync(command);
            return Ok();
        }
        [HttpGet("group/{email}")]
        public async Task<ActionResult<RaApplicationDTO>> GetGroup(string email)
        {
            var command = new GetGroupCommand() { Email = email };
            await mediator.SendAsync(command);
            return Ok();
        }
    }
}
