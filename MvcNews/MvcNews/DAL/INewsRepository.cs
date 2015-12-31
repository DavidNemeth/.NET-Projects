using MvcNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcNews.DAL
{
    public interface INewsRepository :IDisposable
    {
        IList<News> GetAllNews();
        IList<Category> GetAllCategory();
        IList<NewsTag> GetAllTags();
        IList<News> CategoryFilter(int? CatID);
    }
}
