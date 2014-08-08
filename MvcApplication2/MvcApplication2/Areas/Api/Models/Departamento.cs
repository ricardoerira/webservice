using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Areas.Api.Models
{
    public class Departamento
    {

        public int departamentoId { get; set; }
        public string dep_nombre { get; set; }
        public string est_codigo { get; set; }
        public int paisId { get; set; }
        public Pais Paises { get; set; }
    }
}