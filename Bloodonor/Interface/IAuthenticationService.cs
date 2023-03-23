using Bloodonor.Models;

namespace Bloodonor.Interface
{
    public interface IAuthenticationService
    {
        Task<bool> Signout();

        User AuthenticateUser(string UserName, string Password);

        User GetUser(string UserName);
    }
}
