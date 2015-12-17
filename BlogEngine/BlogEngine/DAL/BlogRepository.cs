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
        public Post GetPost(int postid)
        {
            return context.Posts.Find(postid);
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

        public int TotalPosts()
        {
            return context.Posts.Count();
        }
        public Tag GetTag(string tagname)
        {
            return context.Tags.Where(x => x.Name == tagname).FirstOrDefault() ?? new Tag() { Name = tagname };
        }
        public Post GetPost(int? id)
        {
            return id.HasValue ? context.Posts.Where(x => x.Id == id).First() : new Post() { Id = -1 };
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void AddPost(Post post)
        {
            context.Posts.Add(post);
            Save();
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