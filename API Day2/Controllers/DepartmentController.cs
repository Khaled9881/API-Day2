using API_Day2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ITIContext iTIContext;

        public DepartmentController(ITIContext iTIContext)
        {
            this.iTIContext = iTIContext;
        }

        //[HttpGet]
        //public IActionResult getAll()
        //{

        //}
    }
}
