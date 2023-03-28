using blog_api.Models;

namespace blog_api.Service.Interface
{
    public interface ICalendarService
    {
        List<ICalendarEvent> GetList();
    }
}
