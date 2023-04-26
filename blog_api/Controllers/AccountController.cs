using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public AccountController() { }

        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult(null);
        }

        //[HttpGet("")]
        //public IActionResult GetProfiles()
        //{
        //}
    }
}
