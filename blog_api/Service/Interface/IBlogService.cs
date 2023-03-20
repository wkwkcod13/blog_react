using blog_api.Models;

namespace blog_api.Service.Interface
{
    public interface IBlogService
    {
        int CreateBlog(IBlog blog);
        IBlog? GetBlogByIndex(int index);
        BlogList<IBlog> GetBlogList();
    }
}
