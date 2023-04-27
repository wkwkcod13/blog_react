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
using System.Security.Claims;
using blog_api.Service.Interface;

namespace blog_api.Controllers
{
    [ApiController]
    [CorsFilter]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private JwtHelper _jwtHelper;
        private IAntiforgery _antiforgery;
        private IAuthService _authService;
        public AuthController(JwtHelper helper, IAntiforgery antiforgery, IAuthService authService)
        {
            _antiforgery = antiforgery;
            _jwtHelper = helper;
            _authService = authService;
        }

        [HttpPost("loginE")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult ELogin([FromBody] ParaELogin para)
        {
            try
            {
                if (_authService.AuthenticateUser(para.Account, para.Password))
                {
                    Dictionary<string, string> claims = new Dictionary<string, string>();
                    claims.Add(ClaimTypes.UserData, Guid.NewGuid().ToString());
                    var token = _jwtHelper.GenerateEncryptionToken(para.Account, Guid.NewGuid().ToString(), new List<string>() { "user", "admin" }, claims);
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
                if (_authService.AuthenticateUser(userName, password))
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

        [HttpGet("AntiForgeryToken")]
        [HttpHead("AntiForgeryToken")]
        public IActionResult GetAntiForgeryToken()
        {
            AntiforgeryTokenSet token = _antiforgery.GetAndStoreTokens(Request.HttpContext);
            return new JsonResult(new { requestToken = token.RequestToken, Orign = Request.Headers.Origin });
        }
    }
}
