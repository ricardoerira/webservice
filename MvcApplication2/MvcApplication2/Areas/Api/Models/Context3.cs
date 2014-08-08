using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;




namespace MvcApplication2.Areas.Api.Models
{
    public class Context4 : DbContext
    {
         
        public DbSet<Pais> Paises { get; set; }

        public DbSet<Departamento> Departamentoes { get; set; }

        public DbSet<Municipio> Municipios { get; set; }

        public DbSet<TipoUsuario> TipoIdentificacions { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<TipoDocumento> TipoDocumentoes { get; set; }


    }
}