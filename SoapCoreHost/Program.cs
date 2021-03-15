using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace SoapCoreHost
{
    internal class Program
    {
        /// <summary>
        /// Main  from SoapCore sample code
        /// </summary>
        public static void Main()
        {
            var host = new WebHostBuilder()
                .UseKestrel(x => x.AllowSynchronousIO = true)
                .UseUrls("http://*:5050")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .ConfigureLogging(x =>
                {
                    x.AddDebug();
                    x.AddConsole();
                })
                .Build();

            host.Run();
        }
    }
}