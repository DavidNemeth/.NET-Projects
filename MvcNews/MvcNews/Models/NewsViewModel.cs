using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcNews.Models
{
    public class NewsViewModel
    {
        public News News { get; set; }
        public IEnumerable<SelectListItem> NewsTags { get; set; }

        private List<int> newsTag;
        public List<int> _newsTag
        {
            get
            {
                if (newsTag == null)
                {
                    newsTag = News.NewsTags.Select(t => t.Id).ToList();
                }
                return newsTag;
            }
            set { newsTag = value; }
        }
    }
}