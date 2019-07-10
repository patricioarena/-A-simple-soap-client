using System;
using System.Collections.Generic;
using System.Text;

namespace CallSOAP.Models
{
    public class BoletaPagoTasaJustica : Object
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string ImpuestoAbonar { get; set; }
        public string Caratula { get; set; }
        public string BaseImponible { get; set; }
        public string idOrganismo { get; set; }
        public string LetraReceptoria { get; set; }
        public string NumeroReceptoria { get; set; }
        public string SufijoReceptoria { get; set; }
        public string CodigoBarras { get; set; }
        public string DetalleError { get; set; }
    }
}
