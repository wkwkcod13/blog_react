using blog_api.Helper;
using blog_api.Models;
using blog_api.Service.Interface;
using blog_api.Service;
using System.Text.Json;

namespace blog_api.Extensions
{
    public static class CustomServiceCollectionServiceExtensions
    {
        public static IServiceCollection AddCustomServiceCollection(this IServiceCollection collection)
        {
            collection.AddSingleton(new JsonSerializerOptions()
            {
                MaxDepth = 256,
                WriteIndented = false,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            collection.AddSingleton<JwtHelper>();
            collection.AddSingleton<IAuthService, AuthService>();
            collection.AddSingleton<IBlogService, BlogService>();
            collection.AddSingleton<ICalendarService, CalendarService>();
            collection.AddSingleton<ICalendarFactory, CalendarFactory>();
            collection.AddScoped<IAccountService, AccountService>();
            return collection;
        }
    }
}
