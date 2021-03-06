using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace pustalorc.xyz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.ConfigureKestrel(options =>
                    {
                        options.Limits.MinRequestBodyDataRate = null;
                        options.ListenLocalhost(50050,
                            listenOptions => listenOptions.Protocols = HttpProtocols.Http1AndHttp2);
                    })
                    .UseStartup<Startup>());
        }
    }
}