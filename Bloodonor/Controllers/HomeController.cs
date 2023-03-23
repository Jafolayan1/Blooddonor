using Bloodonor.Interface;
using Bloodonor.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Bloodonor.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(IUserAccessor userAccessor, ILogger<HomeController> logger, ApplicationDbContext context) : base(userAccessor)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var bloods = _context.BloodGroups.ToList();
            var location = _context.Locations.ToList();

            ViewBag.bloodGroups = bloods;
            ViewBag.location = location;

            return View(bloods);
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Location(int bloodgroupid, int locationid)
        {
            if (locationid > 0)
            {
                ViewData["branches"] = _context.Branches.Where(x => x.LocationId == locationid).ToList();
                return View();

            }
            ViewData["branches"] = _context.Branches.ToList();
            return View();
        }


        public IActionResult Donate()
        {
            var location = _context.Locations.ToList();
            ViewBag.location = location;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}