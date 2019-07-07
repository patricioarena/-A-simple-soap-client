using System;
using System.IO;
using CallSOAP;
using CallSOAP.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UsingSOAPRequest
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup() {
            Configuration = new ConfigurationBuilder()
                    .AddJsonFile("D:/Desktop/SOAPClient/appsettings.json")
                    .Build();
        }

         public IServiceCollection ConfigureServices()
        {
            return new ServiceCollection()
                .AddLogging()
                .AddMemoryCache()
                .AddSingleton<IConfigurationRoot>(Configuration)
                .AddSingleton<IHelperSoapRequest, HelperSoapRequest>()
                .AddSingleton<IHelperCustomCast, HelperCustomCast>();
        }

    }
}