using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;

namespace CallSOAP
{
    public interface IHelperSoapRequest
    {
        string InvokeService();
        HttpWebRequest CreateSOAPWebRequest();
        string JsonResponse(string input);
    }
}
