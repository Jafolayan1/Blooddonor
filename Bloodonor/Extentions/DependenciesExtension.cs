using AspNetCoreHero.ToastNotification;

using Bloodonor.Configuration;
using Bloodonor.Helper;
using Bloodonor.Interface;
using Bloodonor.Services;

namespace Bloodonor.Extentions
{
    public static class DependenciesExtension
    {
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddTransient<IMailService, MailService>();
            services.AddTransient<IFileHelper, FileHelper>();
            services.AddTransient<IUserAccessor, UserAccessor>();

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });


            //services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });
        }
    }
}
