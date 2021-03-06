using System;
using FixFactorLogin.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FixFactorSystem.Areas.Identity.IdentityHostingStartup))]
namespace FixFactorSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Context>()
                       .AddSignInManager()
    .AddDefaultTokenProviders(); ;


            });
        }
    }
}