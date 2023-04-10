using blog_api.Models;
using blog_api.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;

namespace blog_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;
        public BlogController(IBlogService service)
        {
            blogService = service;
        }
        [HttpHead]
        public IActionResult GetHead()
        {
            return new JsonResult(null);
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult GetList()
        {
            BlogList<IBlog>? list = default;
            try
            {
                list = blogService.GetBlogList();
            }
            catch (Exception ex)
            {
            }
            return new JsonResult(list);
        }

        [HttpGet("{index}")]
        public IActionResult GetDetail(int index)
        {
            try
            {
                return new JsonResult(blogService.GetBlogByIndex(index));
            }
            catch (Exception ex) { }
            return new JsonResult(null);
        }

        [HttpPost()]
        public IActionResult CreateDetail(Blog param)
        {
            try
            {
                if (blogService.CreateBlog(param) > -1)
                {
                    return new JsonResult(true);
                }
            }
            catch (Exception ex) { }
            return new JsonResult(false);
        }

        [HttpPut()]
        public IActionResult UpdateDetail(object param)
        {
            try
            {

            }
            catch { }
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
            try
            {
                IBlog? blog = blogService.Delete(id);
                return new JsonResult(blog);
            }
            catch (Exception ex)
            {
            }
            return new JsonResult(null);
        }
    }
}
