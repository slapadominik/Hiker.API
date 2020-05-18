using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Hiker.API
{
    public class Program
    {
        private static string GetKeyVaultEndpoint() => Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    /*var root = config.Build();
                    config.AddAzureKeyVault(
                        $"https://{root["KeyVault:VaultName"]}.vault.azure.net/",
                    root["KeyVault:ClientId"],
                    root["KeyVault:ClientSecret"]);*/
                })
                .UseUrls("http://*:5000")
                .UseStartup<Startup>();
    }
}
