using CallSOAP;
using CallSOAP.IServices;
using CallSOAP.Models;
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

            CodigoBarrasTasaJusticia codigoBarras = new CodigoBarrasTasaJusticia();

            codigoBarras.Nombre = "Carlos Armando";
            codigoBarras.Apellido = "Mulet";
            codigoBarras.ImpuestoAbonar = "10000";
            codigoBarras.TipoDocumento = "6";
            codigoBarras.NroDocumento = "33688645";
            codigoBarras.Caratula = "Mulet Carlos Armando";
            codigoBarras.BaseImponible = "500.3";
            codigoBarras.idOrganismo = "3";
            codigoBarras.LetraReceptoria = "ZC";
            codigoBarras.NumeroReceptoria = "3420";
            codigoBarras.SufijoReceptoria = "2018";
            codigoBarras.DetalleError = "?";

            BoletaPagoTasaJustica boletaPago = new BoletaPagoTasaJustica();

            boletaPago.Nombre = "Carlos Armando";
            boletaPago.Apellido = "Mulet";
            boletaPago.ImpuestoAbonar = "10000";
            boletaPago.TipoDocumento = "6";
            boletaPago.NroDocumento = "33688645";
            boletaPago.Caratula = "Mulet Carlos Armando";
            boletaPago.BaseImponible = "500.3";
            boletaPago.idOrganismo = "3";
            boletaPago.LetraReceptoria = "ZC";
            boletaPago.NumeroReceptoria = "3420";
            boletaPago.SufijoReceptoria = "2018";
            boletaPago.DetalleError = "?";
            boletaPago.CodigoBarras = "66465010110000000021036000336886451881900011369697";

            IServiceProvider serviceProvider = startup.ConfigureServices()
                .BuildServiceProvider();

            // Get Services
            var HelperSoap = serviceProvider.GetService<IHelperSoapRequest>();
            var CustomCast = serviceProvider.GetService<IHelperCustomCast>();

            // Use Services and methods
            CustomCast.Generate(codigoBarras);
            //CustomCast.Generate(boletaPago);

            var response = HelperSoap.InvokeService();
            Console.WriteLine(response);




        }

    }
}