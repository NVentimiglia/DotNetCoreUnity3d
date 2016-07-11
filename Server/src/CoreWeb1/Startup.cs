using System.Collections.Generic;
using System.Linq;
using CoreWeb1.Infrastructure;
using CoreWeb1.Modules.Score;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreWeb1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Things such as..
            // Debug level
            // database connection strings
            // admin email address
            // and other quasi dynamic configuration data
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {

            //our routing framework
            services.AddMvc();

            //support for custom view location
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new ModuleViewLocator());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //enable web sockets
            app.UseWebSockets();

            //wire our chat service
            app.Use(ChatService.ChatHandler);

            // this enables routing / controller framework
            app.UseMvc();

            //ensure DB is configured
            using (var context = new ScoreContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
