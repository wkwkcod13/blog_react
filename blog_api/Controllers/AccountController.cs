using blog_api.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Net.Mime;
using System.Security.Claims;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace blog_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult(null);
        }

        [HttpGet("GetProfiles")]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult GetProfiles()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                Predicate<Claim> predicate = predicate =>
                {
                    return predicate.Type.Equals(ClaimTypes.UserData);
                };
                if (User.HasClaim(predicate))
                {
                    return new JsonResult(_accountService.GetProfiles(User.FindFirst(predicate)?.Value ?? ""));
                }
            }
            return new JsonResult(null);
        }
    }
}
