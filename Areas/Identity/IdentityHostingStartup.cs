using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftwareHouseManagement.Areas.Identity.Data;
using SoftwareHouseManagement.Data;

//[assembly: HostingStartup(typeof(SoftwareHouseManagement.Areas.Identity.IdentityHostingStartup))]
//namespace SoftwareHouseManagement.Areas.Identity
//{
//    //public class IdentityHostingStartup : IHostingStartup
//    {
//        //public void Configure(IWebHostBuilder builder)
//        //{
//        //    builder.ConfigureServices((context, services) => {
//        //        services.AddDbContext<SoftwareHouseManagementContext>(options =>
//        //            options.UseSqlServer(
//        //                context.Configuration.GetConnectionString("SoftwareHouseManagementContextConnection")));

//        //        services.AddDefaultIdentity<SoftwareHouseManagementUser>(options => options.SignIn.RequireConfirmedAccount = true)
//        //            .AddEntityFrameworkStores<SoftwareHouseManagementContext>();
//        //    });
//        //}
//    }
//}