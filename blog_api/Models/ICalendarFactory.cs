namespace blog_api.Models
{
    public interface ICalendarFactory
    {
        ICalendarEvent ConvertFromBlog(IBlog blog);
    }
}
