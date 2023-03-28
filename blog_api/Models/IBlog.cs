namespace blog_api.Models
{
    public interface IBlog
    {
        string BlogId { get; set; }
        string SubDescription { get; set; }
        DateTime CreateDate { get; set; }
        string AuthorId { get; set; }
        string AuthorName { get; set; }
        string Title { get; set; }
    }
}
