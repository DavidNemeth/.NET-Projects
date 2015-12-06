using BlogEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogEngine.DAL
{
    public class BlogRepository : IBlogRepository, IDisposable
    {
        public BlogContext context;
        public BlogRepository(BlogContext _context)
        {
            context = _context;
        }

        public IList<Post> GetPosts()
        {
            return context.Posts.ToList();
        }
        public IList<Category> GetCategory(Post post)
        {
            var catid = context.Categories.Where(p => p.Id == post.Id)
                .Select(p => p.Id).ToList();
            List<Category> cats = new List<Category>();
            foreach (var cat in catid)
            {
                cats.Add(context.Categories.Where(p => p.Id == cat).FirstOrDefault());
            }
            return cats;
        }
        public IList<Tag> GetTags(Post post)
        {
            var tagid = context.Tags.Where(p => p.Id == post.Id)
                .Select(p => p.Id).ToList();
            List<Tag> tags = new List<Tag>();
            foreach (var tag in tagid)
            {
                tags.Add(context.Tags.Where(p => p.Id == tag).FirstOrDefault());
            }
            return tags;
        }





        #region Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion Dispose
    }
}