using blog_api.Helper;
using blog_api.Models;
using blog_api.Service.Interface;
using blog_api.Service;

namespace blog_api.Handler
{
    public static class CustomServiceCollectionServiceExtensions
    {
        public static IServiceCollection AddCustomServiceCollection(this IServiceCollection collection)
        {
            collection.AddSingleton<JwtHelper>();
            collection.AddSingleton<IBlogService, BlogService>();
            collection.AddSingleton<ICalendarService, CalendarService>();
            collection.AddSingleton<ICalendarFactory, CalendarFactory>();
            return collection;
        }
    }
}
