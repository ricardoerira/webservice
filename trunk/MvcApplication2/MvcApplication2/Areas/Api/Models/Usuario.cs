using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Areas.Api.Models
{
    public class Usuario
    {
        public int usuarioId { get; set; }
        public string usu_nombre { get; set; }
        public string usu_apellido { get; set; }
        public int tipoDocumentoId { get; set; }
        public string usu_identificacion { get; set; }
        public int tipoUsuarioId { get; set; }
        public string usu_fnacimiento { get; set; }
        public int sex_codigo { get; set; }
        public int usu_celular { get; set; }
        public int municipioId { get; set; }
        public string idfacebook { get; set; }
        public string idtwitter { get; set; }
        public string usu_username { get; set; }
        public string usu_passwd { get; set; }
        public string est_codigo { get; set; }
        public Usuario usuarios { get; set; }
        public TipoDocumento TipoDocumentos { get; set; }

        public TipoUsuario TipoUsuarios { get; set; }
        public Municipio Municipios { get; set; }


    }
}