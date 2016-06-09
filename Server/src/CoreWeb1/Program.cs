using System.IO;
using CoreWeb1.Modules.Score;
using Microsoft.AspNetCore.Hosting;

namespace CoreWeb1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Config the database
            ConfigureDB();

            //Config a http web server
            ConfigWebServer();
        }

        static void ConfigureDB()
        {
            using (var db = new ScoreContext())
            {
                db.Database.EnsureCreated();

                // Note migrations are not yet 100%
                // this would handle drop/create and data seeding 
            }
        }

        static void ConfigWebServer()
        {
            var host = new WebHostBuilder()
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
