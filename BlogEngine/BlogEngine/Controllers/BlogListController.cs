using BlogEngine.DAL;
using BlogEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogEngine.Controllers
{
    public class BlogListController : Controller
    {
        private IBlogRepository blogRepository;
        public static List<BlogListViewModel> postList = new List<BlogListViewModel>();
        public BlogListController()
        {
            blogRepository = new BlogRepository(new BlogContext());
        }
        public BlogListController(IBlogRepository _blogRepository)
        {
            _blogRepository = blogRepository;
        }
        [HttpGet]
        [AllowAnonymous]



        #region main
        public ActionResult Index()
        {
            Posts();
            return View();
        }
        public ActionResult Posts()
        {            
            return PartialView("Posts");
        }
        #endregion main




        #region helpers
        public IList<Post> GetPosts()
        {
            return blogRepository.GetPosts();
        }
        //public IList<Category> GetPostCategory(Post post)
        //{
        //    return blogRepository.GetPostCategory(post);
        //}
        //public IList<Tag> GetPostTag(Post post)
        //{
        //    return blogRepository.GetPostTags(post);
        //}

        #endregion helpers
    }
}