namespace blog_api.Service.Interface
{
    public interface IAuthService
    {
        bool AuthenticateUser(string username, string password);
    }
}
