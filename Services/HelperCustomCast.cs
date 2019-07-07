using CallSOAP.IServices;
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
    public class HelperCustomCast : IHelperCustomCast
    {
        private readonly string xml;
        private readonly IConfiguration Configuration;
        private IMemoryCache MemoryCache;
        public HelperCustomCast(IConfigurationRoot configuration, IMemoryCache memoryCache)
        {
            Configuration = configuration;
            MemoryCache = memoryCache;
            xml = Configuration["SOAP:GenerarCodigoDeBarrasDePago.xml"];
        }

        public void read()
        {
            //Creo un nuevo elemento xml
            XmlDocument modelXML = new XmlDocument();
            //Lo cargo con el modelo xml necesario
            modelXML.Load(xml);

            //Clono el modelo de xml a un nuevo xml
            XmlDocument newXML = (XmlDocument)modelXML.CloneNode(true);
 
            //Le asigno los valores del objecto al xml
            var Nombre = newXML.GetElementsByTagName("Nombre")[0].InnerXml = "Carlos Armando";
            var Apellido = newXML.GetElementsByTagName("Apellido")[0].InnerXml = "Mulet";
            var ImpuestoAbonar = newXML.GetElementsByTagName("ImpuestoAbonar")[0].InnerXml = "100000";
            var TipoDocumento = newXML.GetElementsByTagName("TipoDocumento")[0].InnerXml = "6";
            var NroDocumento = newXML.GetElementsByTagName("NroDocumento")[0].InnerXml = "33688645";
            var Caratula = newXML.GetElementsByTagName("Caratula")[0].InnerXml = "Mulet Carlos Armando";
            var BaseImponible = newXML.GetElementsByTagName("BaseImponible")[0].InnerXml = "500.3";
            var idOrganismo = newXML.GetElementsByTagName("idOrganismo")[0].InnerXml = "3";
            var LetraReceptoria = newXML.GetElementsByTagName("LetraReceptoria")[0].InnerXml = "ZC";
            var NumeroReceptoria = newXML.GetElementsByTagName("NumeroReceptoria")[0].InnerXml = "3420";
            var SufijoReceptoria = newXML.GetElementsByTagName("SufijoReceptoria")[0].InnerXml = "2018";
            var DetalleError = newXML.GetElementsByTagName("DetalleError")[0].InnerXml = "?";

            // Si el objeto de entra es de tipo BoletaPagoTasaJustica tambien setear esto
            var CodigoBarras = newXML.GetElementsByTagName("CodigoBarras")[0].InnerXml = "2018";
            
            //Guardo el xml que se enviara al servicio soap en memoria cache 
            MemoryCache.Set("xml",newXML);

            //ver xml en consola
            newXML.Save(Console.Out);

        }
    }
}
