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
        public News News { get; set; }
        public IEnumerable<SelectListItem> AllTags { get; set; }
        

        private List<int> _newsTag;
        public List<int> newsTag
        {
            get
            {
                if (_newsTag == null)
                {
                    _newsTag = News.NewsTags.Select(t => t.TagId).ToList();
                }
                return _newsTag;
            }
            set { _newsTag = value; }
        }
    }
}