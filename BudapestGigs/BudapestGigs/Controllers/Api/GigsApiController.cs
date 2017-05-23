using BudapestGigs.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace BudapestGigs.Controllers.Api
{
    public class GigsApiController : ApiController
    {
        private ApplicationDbContext _context;

        public GigsApiController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            string userid = User.Identity.GetUserId();
            var gig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userid);
            gig.IsCanceled = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
