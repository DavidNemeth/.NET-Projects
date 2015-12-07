using BlogEngine.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogEngine.Models
{
    public class BlogListViewModel
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string UrlOpt { get; set; }
        public DateTime PostedDate { get; set; }
        public IList<Category> Category { get; set; }
        public IList<Tag> Tags { get; set; }
        public Post Post { get; set; }
    }
}