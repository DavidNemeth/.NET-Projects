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
            var posts = context.GetPosts();
            var BlogListViewModel = new BlogListViewModel(context)
            {
                Posts = posts
            };
            ViewBag.Title = "Posts";

            return View("List", BlogListViewModel);
        }
    }
}