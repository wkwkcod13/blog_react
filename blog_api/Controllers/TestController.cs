using Microsoft.AspNetCore.Mvc;
using blog_api.Models.Test;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;

namespace blog_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]

    public class TestController : ControllerBase
    {
        public TestController() { }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult GetTest()
        {
            try
            {
                MessageList messageList = new MessageList() { new TextMessage(), new PhotoMessage() };
                messageList.Add(new TextMessage());
                messageList.Add(new PhotoMessage());
                return new JsonResult(messageList);
            }
            catch (Exception ex)
            {

            }
            return new JsonResult(null);
        }

        [HttpPost("Post2")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult PostTest2(IEnumerable<IMessage> messages)
        {
            try
            {
                foreach (var message in messages)
                {
                    if (message is TextMessage text)
                    {
                    }
                    if (message is PhotoMessage photo)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return new JsonResult(messages);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult PostTest(MessageList messages)
        {
            try
            {
                foreach (var message in messages)
                {
                    if (message is TextMessage text)
                    {
                    }
                    if (message is PhotoMessage photo)
                    {
                    }
                }
                return new JsonResult(messages);
            }
            catch (Exception ex)
            {

            }
            return new JsonResult(null);
        }
    }
}
