using System;
using System.Collections.Generic;
using System.Text;

namespace CallSOAP.Models
{
    public class BoletaPagoTasaJustica
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public decimal ImpuestoAbonar { get; set; }
        public string Caratula { get; set; }
        public decimal BaseImponible { get; set; }
        public int idOrganismo { get; set; }
        public string LetraReceptoria { get; set; }
        public int NumeroReceptoria { get; set; }
        public string SufijoReceptoria { get; set; }
        public string CodigoBarras { get; set; }
        public string DetalleError { get; set; }
    }
}
