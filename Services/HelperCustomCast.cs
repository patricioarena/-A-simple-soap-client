using CallSOAP.IServices;
using CallSOAP.Models;
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
        private readonly string GenerarCodigoDeBarrasDePago;
        private readonly string GenerarBoletaDePagoTasaDeJusticia;
        private readonly IConfiguration Configuration;
        private IMemoryCache MemoryCache;

        public HelperCustomCast(IConfigurationRoot configuration, IMemoryCache memoryCache)
        {
            Configuration = configuration;
            MemoryCache = memoryCache;
            GenerarCodigoDeBarrasDePago = Configuration["SOAP:GenerarCodigoDeBarrasDePago.xml"];
            GenerarBoletaDePagoTasaDeJusticia = Configuration["SOAP:GenerarBoletaDePagoTasaDeJusticia.xml"];
        }

        public void Generate(Object model)
        {
            //Creo un nuevo elemento xml
            XmlDocument modelXML = new XmlDocument();
            //Lo cargo con el modelo xml necesario
            modelXML.Load(GenerarCodigoDeBarrasDePago);
            //Clono el modelo de xml a un nuevo xml
            XmlDocument newXML = (XmlDocument)modelXML.CloneNode(true);

            bool fueCasteado = false;

             if (model.GetType().Name.Equals("BoletaPagoTasaJustica") && fueCasteado == false)
            {
                BoletaPagoTasaJustica boletaPago = (BoletaPagoTasaJustica)model;
                modelXML.Load(GenerarBoletaDePagoTasaDeJusticia);
                newXML = (XmlDocument)modelXML.CloneNode(true);

                fueCasteado = true;
                //Console.WriteLine("Type is {0}", model.GetType().Name);
                var CodigoBarras = newXML.GetElementsByTagName("CodigoBarras")[0].InnerXml = boletaPago.CodigoBarras;
            }
            if ((model.GetType().Name.Equals("CodigoBarrasTasaJusticia") && fueCasteado == false) || (model.GetType().Name.Equals("BoletaPagoTasaJustica") && fueCasteado == true))
            {
                if (fueCasteado == false)
                {
                    CodigoBarrasTasaJusticia codigoBarras = (CodigoBarrasTasaJusticia)model;
                    //Le asigno los valores del objecto al xml
                    var Nombre = newXML.GetElementsByTagName("Nombre")[0].InnerXml = codigoBarras.Nombre;
                    var Apellido = newXML.GetElementsByTagName("Apellido")[0].InnerXml = codigoBarras.Apellido;
                    var ImpuestoAbonar = newXML.GetElementsByTagName("ImpuestoAbonar")[0].InnerXml = codigoBarras.ImpuestoAbonar;
                    var TipoDocumento = newXML.GetElementsByTagName("TipoDocumento")[0].InnerXml = codigoBarras.TipoDocumento;
                    var NroDocumento = newXML.GetElementsByTagName("NroDocumento")[0].InnerXml = codigoBarras.NroDocumento;
                    var Caratula = newXML.GetElementsByTagName("Caratula")[0].InnerXml = codigoBarras.Caratula;
                    var BaseImponible = newXML.GetElementsByTagName("BaseImponible")[0].InnerXml = codigoBarras.BaseImponible;
                    var idOrganismo = newXML.GetElementsByTagName("idOrganismo")[0].InnerXml = codigoBarras.idOrganismo;
                    var LetraReceptoria = newXML.GetElementsByTagName("LetraReceptoria")[0].InnerXml = codigoBarras.LetraReceptoria;
                    var NumeroReceptoria = newXML.GetElementsByTagName("NumeroReceptoria")[0].InnerXml = codigoBarras.NumeroReceptoria;
                    var SufijoReceptoria = newXML.GetElementsByTagName("SufijoReceptoria")[0].InnerXml = codigoBarras.SufijoReceptoria;
                    var DetalleError = newXML.GetElementsByTagName("DetalleError")[0].InnerXml = codigoBarras.DetalleError;
                }
                if (fueCasteado == true)
                {
                    BoletaPagoTasaJustica boletaPago = (BoletaPagoTasaJustica)model;
                    //Le asigno los valores del objecto al xml
                    var Nombre = newXML.GetElementsByTagName("Nombre")[0].InnerXml = boletaPago.Nombre;
                    var Apellido = newXML.GetElementsByTagName("Apellido")[0].InnerXml = boletaPago.Apellido;
                    var ImpuestoAbonar = newXML.GetElementsByTagName("ImpuestoAbonar")[0].InnerXml = boletaPago.ImpuestoAbonar;
                    var TipoDocumento = newXML.GetElementsByTagName("TipoDocumento")[0].InnerXml = boletaPago.TipoDocumento;
                    var NroDocumento = newXML.GetElementsByTagName("NroDocumento")[0].InnerXml = boletaPago.NroDocumento;
                    var Caratula = newXML.GetElementsByTagName("Caratula")[0].InnerXml = boletaPago.Caratula;
                    var BaseImponible = newXML.GetElementsByTagName("BaseImponible")[0].InnerXml = boletaPago.BaseImponible;
                    var idOrganismo = newXML.GetElementsByTagName("idOrganismo")[0].InnerXml = boletaPago.idOrganismo;
                    var LetraReceptoria = newXML.GetElementsByTagName("LetraReceptoria")[0].InnerXml = boletaPago.LetraReceptoria;
                    var NumeroReceptoria = newXML.GetElementsByTagName("NumeroReceptoria")[0].InnerXml = boletaPago.NumeroReceptoria;
                    var SufijoReceptoria = newXML.GetElementsByTagName("SufijoReceptoria")[0].InnerXml = boletaPago.SufijoReceptoria;
                    var DetalleError = newXML.GetElementsByTagName("DetalleError")[0].InnerXml = boletaPago.DetalleError;

                }
                //Guardo el xml que se enviara al servicio soap en memoria cache 
                MemoryCache.Set("xml", newXML);

                //ver xml en consola
                newXML.Save(Console.Out);
            }
        }
    }
}
