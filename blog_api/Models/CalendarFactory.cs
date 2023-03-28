namespace blog_api.Models
{
    public class CalendarFactory : ICalendarFactory
    {
        public ICalendarEvent ConvertFromBlog(IBlog blog)
        {
            try
            {
                ICalendarEvent item = new CalendarEvent()
                {
                    Id = blog.BlogId,
                    Title = blog.Title,
                    StartDate = blog.CreateDate,
                    EndDate = blog.CreateDate,
                };
                return item;
            }
            catch
            {
                throw;
            }
        }
    }
}
