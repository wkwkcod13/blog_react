using Microsoft.AspNetCore.Mvc;
using blog_api.Models.Test;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

        [HttpGet("Claims/{claimNames}")]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult GetClaim(string claimNames)
        {
            try
            {
                if (User.Identity?.IsAuthenticated ?? false)
                {
                    List<Claim> claims = User.Claims.ToList();
                    Predicate<Claim> predicate = predicate =>
                    {
                        return predicate.Type.Equals(claimNames);
                    };

                    if (User.HasClaim(predicate))
                    {
                        Claim? claim = User.FindFirst(predicate);
                        return new JsonResult(claim);
                    }
                }
            }
            catch { }
            return new JsonResult(null);
        }

        [HttpGet("Claims")]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult GetClaims()
        {
            try
            {
                if (User.Identity?.IsAuthenticated ?? false)
                {
                    return new JsonResult(User.Claims.Select(
                        item =>
                        {
                            return new { item.Type, item.Value };
                        }));
                }
            }
            catch { }
            return new JsonResult(null);
        }

        [HttpGet("Roles")]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult GetRoles()
        {
            try
            {
                if (User.Identity?.IsAuthenticated ?? false)
                {
                    Predicate<Claim> predicate = predicate =>
                    {
                        return predicate.Type.Equals(ClaimTypes.Role);
                    };
                    if (User.HasClaim(predicate))
                    {
                        return new JsonResult(
                            User.Claims.Where(
                                item => item.Type.Equals(ClaimTypes.Role)
                                ).Select(
                                item => { return new { item.Type, item.Value }; }
                                ).ToList());
                    }
                }
            }
            catch { }
            return new JsonResult(null);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("GetAdminRole")]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult GetAdminRole()
        {
            return Ok();
        }

        [Authorize(Policy = "RequireUserRole")]
        [HttpGet("GetUserRole")]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult GetUserRole()
        {
            return Ok();
        }
    }
}
