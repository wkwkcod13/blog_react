using blog_api.Models;
using blog_api.Service.Interface;
using iText.Html2pdf.Attach.Impl.Tags;
using System.Linq;

namespace blog_api.Service
{
    public class CalendarService : ICalendarService
    {
        private readonly IServiceProvider _provicer;
        private readonly ICalendarFactory _calendarFactory;
        public CalendarService(IServiceProvider provider, ICalendarFactory factory)
        {
            _provicer = provider;
            _calendarFactory = factory;
        }

        public List<ICalendarEvent> GetList()
        {
            IBlogService? blogService = _provicer.GetService<IBlogService>();
            BlogList<IBlog>? blogs = blogService?.GetBlogList();
            var list = blogs?.Select(item => _calendarFactory.ConvertFromBlog(item)).ToList() ?? new List<ICalendarEvent>();
            return list;
        }
    }
}
