using blog_api.Service.Interface;
using iText.Html2pdf.Attach.Impl.Tags;

namespace blog_api.Service
{
    public class CalendarService : ICalendarService
    {
        private readonly IServiceProvider _provicer;
        public CalendarService(IServiceProvider provider)
        {
            _provicer = provider;
        }

        public object? GetList()
        {
            IBlogService? blogService = _provicer.GetService<IBlogService>();
            var list = blogService?.GetBlogList();
            return list;
        }
    }
}
