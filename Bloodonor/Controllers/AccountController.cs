using AspNetCoreHero.ToastNotification.Abstractions;

using Bloodonor.Interface;
using Bloodonor.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics.CodeAnalysis;

namespace Bloodonor.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthenticationService _auth;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMailService _mailService;
        private readonly ApplicationDbContext _context;
        private readonly IFileHelper _file;
        private readonly INotyfService _notyf;
        public AccountController(IAuthenticationService auth, UserManager<User> userManager, SignInManager<User> signInManager, IMailService mailService, ApplicationDbContext context, IFileHelper file, IUserAccessor o, INotyfService notyf) : base(o)
        {
            _auth = auth;
            _userManager = userManager;
            _signInManager = signInManager;
            _mailService = mailService;
            _context = context;
            _file = file;
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["BloodGroup"] = _context.BloodGroups.ToList();
            ViewData["Location"] = _context.Locations.ToList();
            ViewData["Donors"] = _context.Donors.ToList();

            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login login, string returnUrl)
        {
            try
            {
                var userLogin = _auth.AuthenticateUser(login.Email, login.Password);

                if (userLogin != null)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    if (userLogin.Role.Contains("Donor"))
                    {
                        return RedirectToAction("index", "home");
                    }
                    else if (userLogin.Role.Contains("Admin"))
                    {
                        return RedirectToAction("index", "admin");
                    }
                }
                //ModelState.AddModelError("", "Invalid Username/Password");
                TempData["Error"] = "Invalid Username/Password";

                return View();
            }
            catch (Exception)
            {
                TempData["Error"] = "One or more errors occured.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register, [MaybeNull] IFormCollection data, string role)
        {
            try
            {
                User user = new()
                {
                    FullName = register.FullName,
                    UserName = register.Email,
                    //ImageUrl = "https://cdn-icons-png.flaticon.com/512/3135/3135755.png",
                    Email = register.Email,
                    PhoneNumber = register.PhoneNO,
                    //DOB = register.DOB,
                    City = register.City,
                    Address = register.Address,
                    BloodGroup = register.BloodGroup,
                    Gender = register.Gender,
                };

                var request = _userManager.CreateAsync(user, register.Password).Result;
                await _userManager.AddToRoleAsync(user, role);
                if (!request.Succeeded)
                {
                    TempData["Error"] = $"Error registering user";
                    return View();
                }

                var donor = new Donor()
                {
                    UserId = user.Id
                };
                _context.Donors.Add(donor);
                _context.SaveChanges();


                await _signInManager.PasswordSignInAsync(user, register.Password, isPersistent: false, lockoutOnFailure: false);
                return RedirectToAction("index", "home");
            }
            catch (Exception)
            {

                TempData["Error"] = $"One or more errors occured";
                return View();
            }
        }


        //[Route("unauthorized")]
        [HttpGet]
        public IActionResult Unauthorize()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPassword model, MailRequest request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account",
                    new { email = user.Email, token }, protocol: HttpContext.Request.Scheme);

                request.ToEmail = model.Email;
                request.Subject = "Reset Password Token";
                await _mailService.SendEmailAsync(request, $"<a href='{callbackUrl}'>Click this link to reset your paswword,<br>");

                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }
            catch
            {
                ModelState.AddModelError("", "One or more errors occurred.");
                return RedirectToAction(nameof(Login));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordConfirmation));

            var resetPassResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View();
            }
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }



        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            return View(model);
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //[Route("logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _auth.Signout();
            return Redirect("~/");
        }
    }

}

