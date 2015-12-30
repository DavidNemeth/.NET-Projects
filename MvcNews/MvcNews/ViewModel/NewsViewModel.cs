using MvcNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcNews.ViewModel
{
    public class NewsViewModel
    {
        
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime? Modified { get; set; }
        public int Total { get; set; }
        public IList<News> News { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public IList<Category> AllCategory { get; set; }
        public IList<NewsTag> AllTags { get; set; }
        public ICollection<NewsTag> NewsTags { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}