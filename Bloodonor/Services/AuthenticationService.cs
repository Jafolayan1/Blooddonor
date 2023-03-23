using Bloodonor.Interface;
using Bloodonor.Models;

using Microsoft.AspNetCore.Identity;

namespace Bloodonor.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        protected SignInManager<User> _signInManager;
        protected UserManager<User> _userManager;
        protected RoleManager<Role> _roleManager;

        public AuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public User AuthenticateUser(string userName, string Password)
        {
            var result = _signInManager.PasswordSignInAsync(userName, Password, true, false).Result;

            if (result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(userName).Result ?? _userManager.FindByEmailAsync(userName).Result;
                var roles = _userManager.GetRolesAsync(user).Result;
                user.Role = roles.ToArray();

                return user;
            }

            return null;
        }

        //public virtual async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        //{
        //    var user = await _userManager.FindByNameAsync(userName);
        //    if (user == null)
        //    {
        //        return SignInResult.Failed;
        //    }

        //    return await PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        //}

        public User GetUser(string userName)
        {
            return _userManager.FindByNameAsync(userName).Result;
        }

        public async Task<bool> Signout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
