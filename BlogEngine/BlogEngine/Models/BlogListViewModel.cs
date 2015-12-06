using BlogEngine.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogEngine.Models
{
    public class BlogListViewModel
    {
        public BlogListViewModel(IBlogRepository blogRepository)
        {
            Posts = blogRepository.GetPosts();            
        }
        public IList<Post> Posts { get; set; }      
        public Category Category { get; set; }
        public Tag Tag { get; set; }
    }
}