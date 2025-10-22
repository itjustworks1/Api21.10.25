using Microsoft.AspNetCore.Mvc;

namespace Api21._10._25.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationsController : ControllerBase
    {
        [HttpPost("personal")]
        public async void PostPersonal()
        {

        }
        [HttpPost("group")]
        public async void PostGroup()
        {

        }
        [HttpGet("{id}")]
        public async void GetId()
        {

        }
        [HttpGet("personal/{email}")]
        public async void GetPersonal()
        {

        }
        [HttpGet("group/{email}")]
        public async void GetGroup()
        {

        }
    }
}
