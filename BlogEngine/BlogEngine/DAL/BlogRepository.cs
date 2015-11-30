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
        public IList<Category> GetPostCategory(Post post)
        {
            var categoryId = context.PostCategory.Where(p => p.PostId == post.Id).Select(p => p.CategoryId).ToList();
            List<Category> categories = new List<Category>();
            foreach (var catId in categoryId)
            {
                categories.Add(context.Categories.Where(p => p.Id == catId).FirstOrDefault());
            }
            return categories;
        }
        public IList<Tag> GetPostTags(Post post)
        {
            var tagIds = context.PostTags.Where(p => p.PostId == post.Id).Select(p => p.TagId).ToList();
            List<Tag> tags = new List<Tag>();
            foreach (var tagId in tagIds)
            {
                tags.Add(context.Tags.Where(p => p.Id == tagId).FirstOrDefault());
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