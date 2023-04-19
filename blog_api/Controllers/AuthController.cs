using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using blog_api.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Net.Mime;
using blog_api.Models.Para;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Cors;
using blog_api.Handler;

namespace blog_api.Controllers
{
    [ApiController]
    [CorsFilter]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private JwtHelper _jwtHelper;
        private IAntiforgery _antiforgery;
        public AuthController(JwtHelper helper, IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
            _jwtHelper = helper;
        }

        [HttpPost("loginE")]
        [ValidateAntiForgeryToken]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult ELogin([FromBody] ParaELogin para)
        {
            try
            {
                if (AuthenticateUser(para.Account, para.Password))
                {
                    var token = _jwtHelper.GenerateEncryptionToken(para.Account, new Guid().ToString(), new List<string>() { "user", "admin" }, null);
                    return Content(token, MediaTypeNames.Text.Plain);
                }
                else
                {
                    throw new AuthenticationException("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
            }
            return NotFound();
        }

        [HttpGet("login")]
        public IActionResult Login(string userName, string password)
        {
            try
            {
                if (AuthenticateUser(userName, password))
                {
                    var token = _jwtHelper.GenerateToken(userName, new Guid().ToString(), new List<string>() { "user", "admin" }, null);
                    return Ok(new { token });
                }
                else
                {
                    throw new AuthenticationException("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
            }
            return NotFound();
        }

        private bool AuthenticateUser(string username, string password)
        {
            return true;
        }

        [HttpGet("AntiForgeryToken")]
        [HttpHead("AntiForgeryToken")]
        public IActionResult GetAntiForgeryToken()
        {
            AntiforgeryTokenSet token = _antiforgery.GetAndStoreTokens(Request.HttpContext);
            return new JsonResult(new { requestToken = token.RequestToken, Orign = Request.Headers.Origin});
        }
    }
}
