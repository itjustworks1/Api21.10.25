using Microsoft.AspNetCore.Mvc;

namespace Api21._10._25.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApprovalController : ControllerBase
    {
        [HttpGet("requests")]
        public async void GetRequestsByIdDepartment(int id)
        {

        }
        [HttpPost("approve")]
        public async void Approve()
        {

        }
        [HttpPost("reject")]
        public async void Reject()
        {

        }
    }
}
