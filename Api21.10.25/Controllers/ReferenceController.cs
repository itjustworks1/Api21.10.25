using Microsoft.AspNetCore.Mvc;

namespace Api21._10._25.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceController : ControllerBase
    {
        [HttpGet("departments")]
        public async void GetDepartments()
        {

        }
        [HttpGet("departments/{id}/employees")]
        public async void GetEmployeesByIdDepartment()
        {

        }
    }
}
