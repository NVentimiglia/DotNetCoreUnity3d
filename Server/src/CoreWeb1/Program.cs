using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CoreWeb1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
               // Required for docker support
               //.UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_SERVER.URLS"))
               .UseUrls("http://*:80")
               // Kestrel  is the web server
               .UseKestrel()
               // cus windows ?
               .UseIISIntegration()
               // root for our content (resources such as CSS stlyes, donts, images and Yavascript)
               .UseContentRoot(Directory.GetCurrentDirectory())
               // more customized and app specific configuration
               .UseStartup<Startup>()
               // end of configuration
               .Build();

            //Run the web server
            host.Run();
        }
    }
}
