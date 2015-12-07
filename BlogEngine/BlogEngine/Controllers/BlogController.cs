using BlogEngine.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogEngine.Models;

namespace BlogEngine.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository context;
        public static List<BlogListViewModel> PostList = new List<BlogListViewModel>();
        public BlogController()
        {
            context = new BlogRepository(new BlogContext());
        }
        public BlogController(IBlogRepository _context)
        {
            context = _context;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Posts()
        {
            PostList.Clear();
            var posts = context.GetPosts();
            foreach (var post in posts)
            {
                var categories = GetCategories(post);
                var tags = GetTags(post);
                PostList.Add(new BlogListViewModel()
                {
                    Body = post.Body,
                    Tittle = post.Tittle,
                    Description = post.Description,
                    Id = post.Id,
                    PostedDate = post.PostedDate,
                    UrlOpt = post.UrlOpt,
                    Post = post
                });                
            }
            return View("Posts");
        }
        public ActionResult Admin()
        {
            return View();
        }






        #region helper
        public IList<Post> GetPosts()
        {
            return context.GetPosts();
        }
        public IList<Category> GetCategories(Post post)
        {
            return context.GetCategory(post);
        }
        public IList<Tag> GetTags(Post post)
        {
            return context.GetTags(post);
        }
        #endregion
    }
}