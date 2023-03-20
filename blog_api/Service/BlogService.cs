using blog_api.Models;
using blog_api.Service.Interface;
using System.Reflection.Metadata;

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
        public IBlog? Delete(string Id)
        {
            int index = _blogList.IndexById(Id);
            if (index > -1)
            {
                IBlog? blog = (IBlog?)_blogList[index];
                _blogList.RemoveAt(index);
                return blog;
            }
            return null;
        }
        public IBlog? DeleteByIndex(int index)
        {
            IBlog? blog = (IBlog?)_blogList[index];
            _blogList.RemoveAt(index);
            return blog;
        }
    }
}
