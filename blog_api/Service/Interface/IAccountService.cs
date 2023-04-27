using blog_api.Models;

namespace blog_api.Service.Interface
{
    public interface IAccountService
    {
        Profiles GetProfiles(string id);
    }
}
