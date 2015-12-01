using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogEngine.Models
{
    public class BlogListViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string UrlOpt { get; set; }
        public string Body { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public Post Post { get; set; }
        public List<string> Category { get; set; }
        public IList<Category> PostCategory { get; set; }
        public IList<Tag> PostTag { get; set; }
        public IList<Tag> Tag { get; set; }  
    }
}