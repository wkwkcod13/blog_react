using blog_api.Models;
using blog_api.Service.Interface;

namespace blog_api.Service
{
    public class AccountService : IAccountService
    {
        public AccountService()
        {
        }

        public Profiles GetProfiles(string id)
        {
            return new Profiles() { ID = id };
        }
    }
}
