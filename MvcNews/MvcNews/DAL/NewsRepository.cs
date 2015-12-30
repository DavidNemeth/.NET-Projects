using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcNews.Models;
using MvcNews.ViewModel;
using System.Data.Entity.Infrastructure;
namespace MvcNews.DAL
{
    public class NewsRepository : INewsRepository, IDisposable
    {
        private NewsDbContext _context;
        public NewsRepository(NewsDbContext context)
        {
            _context = context;
        }
        public IList<News> GetAllNews()
        {
            return _context.News
                .Include(p => p.Category).Include(t => t.NewsTags)
                .Where(p => p.Published == true)                
                .OrderByDescending(p => p.PostedDate)                
                .ToList();
        }
        public IList<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }
        public IList<NewsTag> GetAllTags()
        {
            return _context.NewsTags.ToList();
        }









        #region dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}