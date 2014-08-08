using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Areas.Api.Models
{
    public class TipoDocumento
    {

        public int tipoDocumentoId { get; set; }
        public string tipo_doc { get; set; }
        public string est_codigo { get; set; }
    }
}