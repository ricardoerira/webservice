using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Areas.Api.Models
{
    public class TipoUsuario
    {
        public int tipoUsuarioId { get; set; }
        public string tusu_nombre { get; set; }
        public string est_codigo { get; set; }
    }
}