using Bloodonor.Interface;
using Bloodonor.Models;

using Microsoft.AspNetCore.Mvc;

namespace Bloodonor.Controllers
{
    public class AdminController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public AdminController(IUserAccessor userAccessor, ApplicationDbContext context) : base(userAccessor)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Donors"] = _context.Donors.ToList();
            ViewData["BloodGroup"] = _context.BloodGroups.ToList();
            ViewData["Location"] = _context.Locations.ToList();
            return View();
        }


        public IActionResult CityList()
        {
            ViewData["Location"] = _context.Locations.ToList();
            return View();
        }

        public IActionResult BloodList()
        {
            ViewData["bloodgroup"] = _context.BloodGroups.ToList();
            return View();
        }
    }
}
