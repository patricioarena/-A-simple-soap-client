using System;
using System.Collections.Generic;
using System.Text;

namespace CallSOAP.Models
{
    public class CodigoBarrasTasaJusticia
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public double ImpuestoAbonar { get; set; }
        public string Caratula { get; set; }
        public int nroJuicio { get; set; }
        public double BaseImponible { get; set; }
        public int idOrganismo { get; set; }
        public string LetraReceptoria { get; set; }
        public int NumeroReceptoria { get; set; }
        public int SufijoReceptoria { get; set; }
        public string DetalleError { get; set; }

    }
}
