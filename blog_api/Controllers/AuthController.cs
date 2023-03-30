using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using blog_api.Helper;
namespace blog_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private JwtHelper _jwtHelper;
        public AuthController(JwtHelper helper)
        {
            _jwtHelper = helper;
        }

        [HttpGet("loginE")]
        public IActionResult ELogin(string userName, string password)
        {
            try
            {
                if (AuthenticateUser(userName, password))
                {
                    var token = _jwtHelper.GenerateEncryptionToken(userName, new Guid().ToString(), null);
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

        [HttpGet("login")]
        public IActionResult Login(string userName, string password)
        {
            try
            {
                if (AuthenticateUser(userName, password))
                {
                    var token = _jwtHelper.GenerateToken(userName, new Guid().ToString(), null);
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
    }
}
