using CallSOAP;
using System;
using System.IO;
using System.Net;
using System.Xml;

namespace UsingSOAPRequest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            var path = @"C:\Users\parena\Desktop\xmlCorte\soap12.xml";
            var url = @"https://tasatesting.scba.gov.ar/ws/service.asmx";

            HelperSoapRequest helper = new HelperSoapRequest(path , url);
            var response = helper.InvokeService();
            
            Console.WriteLine(response);


        }

    }
}