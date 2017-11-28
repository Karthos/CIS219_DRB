using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BearDenFileStorage
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional:true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            

            Configuration = builder.Build();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<FileStorageDbContext>(options => options.UseSqlServer(conn));

            services.AddMvc();
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IMessageService, ConfigurationMessageService>();


            //https://docs.microsoft.com/en-us/aspnet/core/security/authorization/resourcebased?tabs=aspnetcore1x
            services.AddAuthorization(options =>
            {
                options.AddPolicy("FileDetailsPolicy", policy =>
                    policy.Requirements.Add(new SameOwnerRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, FileAuthorizationHandler>();

            services.AddSingleton<IUserFileInfoData, SqlFileInfoData>();
            services.AddSingleton<IUserFileContentData, SqlFileContentData>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<FileStorageDbContext>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,IMessageService msg)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentity();

            //app.UseMvc(ConfigureRoutes);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Files}/{id?}");
                    
            });
            
            app.UseFileServer();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(msg.GetMessage());
            });
        }

        //private void ConfigureRoutes(IRouteBuilder routeBuilder)
        //{
        //    routeBuilder.MapRoute("Default", "{controller=Home}/{action=Files}/{Id?}");
        //}
    }
}
