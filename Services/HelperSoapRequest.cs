using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CallSOAP
{
    public class HelperSoapRequest:IHelperSoapRequest
    {
        private readonly string Url;
        private readonly IConfiguration Configuration;
        private IMemoryCache MemoryCache;
        public HelperSoapRequest(IConfigurationRoot configuration,IMemoryCache memoryCache)
        {
            Configuration = configuration;
            MemoryCache = memoryCache;
            Url = Configuration["SOAP:Url"];
        }

        public string InvokeService()
        {
            HttpWebRequest request = CreateSOAPWebRequest();
            XmlDocument SOAPReqBody = MemoryCache.Get<XmlDocument>("xml");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(Serviceres.GetResponseStream()))
                {
                    var ServiceResult = reader.ReadToEnd();

                    return this.JsonResponse(ServiceResult);
                }
            }
        }

        public HttpWebRequest CreateSOAPWebRequest()
        {
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(Url);
            Req.ContentType = "application/soap+xml;charset=\"utf-8\"";
            Req.Host = "tasatesting.scba.gov.ar";
            Req.Method = "POST";
            return Req;
        }
        public string JsonResponse(string input)
        {
            using (var xReader = XmlReader.Create(new StringReader(input)))
            {
                xReader.MoveToContent();
                xReader.Read();
                XNode node = XNode.ReadFrom(xReader);
                string jsonText = JsonConvert.SerializeXNode(node);
                return jsonText;
            }
        }
    }
}
