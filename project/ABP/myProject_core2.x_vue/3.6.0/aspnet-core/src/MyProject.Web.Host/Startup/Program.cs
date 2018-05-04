using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MyProject.Web.Host.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();
            InitWebHost(args).Run();
        }
        // ?? 防止EF Core调用Program.BuildWebHost()重命名BuildWebHost
        //  public static IWebHost BuildWebHost(string[] args)
        public static IWebHost InitWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
