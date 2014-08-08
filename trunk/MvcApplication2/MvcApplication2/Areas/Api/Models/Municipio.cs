using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Areas.Api.Models
{
    public class Municipio
    {
        public int municipioId { get; set; }
        public string mun_nombre { get; set; }
        public string est_codigo { get; set; }
        public int departamentoId { get; set; }
        public Departamento Departamentos { get; set; }
    }
}