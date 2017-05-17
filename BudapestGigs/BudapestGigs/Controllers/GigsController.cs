using BudapestGigs.Models;
using BudapestGigs.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace BudapestGigs.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var gigviewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(gigviewModel);
        }
    }
}