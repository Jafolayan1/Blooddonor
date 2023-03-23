using Bloodonor.Interface;
using Bloodonor.Models;

using Microsoft.AspNetCore.Mvc;

namespace Bloodonor.Controllers
{
    public class BaseController : Controller
    {
        public User CurrentUser
        {
            get
            {
                if (User != null)
                    return _userAccessor.GetUser();
                else
                    return null;
            }
        }
        private readonly IUserAccessor _userAccessor;


        public BaseController(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }
    }
}
