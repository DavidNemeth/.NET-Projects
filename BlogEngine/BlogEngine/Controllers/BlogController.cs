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
            var posts = context.GetPosts();
            var model = new BlogListViewModel(context);
            return View("Posts", model);
        }
        public ActionResult Admin()
        {
            return View();
        }
    }
}