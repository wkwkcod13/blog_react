using Microsoft.AspNetCore.Mvc;

namespace blog_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        [HttpHead]
        public IActionResult GetHead()
        {
            return new JsonResult(null);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return new JsonResult(null);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail(string id)
        {
            return new JsonResult(null);
        }

        [HttpPost()]
        public IActionResult CreateDetail(object param)
        {
            return new JsonResult(null);
        }

        [HttpPut()]
        public IActionResult UpdateDetail(object param)
        {
            return new JsonResult(null);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchDetail(string id, object param)
        {
            return new JsonResult(null);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return new JsonResult(null);
        }
    }
}
