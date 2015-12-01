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
        //public IList<Category> GetPostCategory(Post post)
        //{            
        //}
        //public IList<Tag> GetPostTags(Post post)
        //{            
        //}





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