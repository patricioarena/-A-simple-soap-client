using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CallSOAP
{
    public class HelperSoapRequest
    {
        private string path;
        private string url;
        public HelperSoapRequest(string path, string url){
            this.path = path;
            this.url = url;
        }
        public string InvokeService()
        {
            HttpWebRequest request = CreateSOAPWebRequest();
            XmlDocument SOAPReqBody = new XmlDocument();

            SOAPReqBody.Load(path);

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    var ServiceResult = rd.ReadToEnd();

                    return this.JsonResponse(ServiceResult);
                }
            }
        }

        public HttpWebRequest CreateSOAPWebRequest()
        {
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(url);
            Req.ContentType = "application/soap+xml;charset=\"utf-8\"";
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
