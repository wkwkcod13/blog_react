using blog_api.Models;
using blog_api.Service.Interface;

namespace blog_api.Service
{
    public class BlogService : IBlogService
    {
        private readonly BlogList<IBlog> _blogList;
        public BlogService()
        {
            _blogList = new BlogList<IBlog>();
        }

        public IBlog? GetBlogByIndex(int index)
        {
            return (IBlog?)_blogList[index];
        }
        public int CreateBlog(IBlog blog)
        {
            return _blogList.Add(blog);
        }
        public BlogList<IBlog> GetBlogList()
        {
            return _blogList;
        }
    }
}
