using blog_api.Service.Interface;

namespace blog_api.Service
{
    public class AuthService : IAuthService
    {
        public AuthService()
        {
        }

        public object Login(string username, string password)
        {
            try
            {
            }
            catch { }
            return new object();
        }

        public bool AuthenticateUser(string username, string password)
        {
            return true;
        }
    }
}
