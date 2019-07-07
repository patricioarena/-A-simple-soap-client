using CallSOAP;
using CallSOAP.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Xml;

namespace UsingSOAPRequest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Startup startup = new Startup();

            IServiceProvider serviceProvider = startup.ConfigureServices()
                .BuildServiceProvider();

            // Get Services
            var HelperSoap = serviceProvider.GetService<IHelperSoapRequest>();
            var CustomCast = serviceProvider.GetService<IHelperCustomCast>();


            // Use Services and methods
            CustomCast.read();
            var response = HelperSoap.InvokeService();
            Console.WriteLine(response);




        }

    }
}