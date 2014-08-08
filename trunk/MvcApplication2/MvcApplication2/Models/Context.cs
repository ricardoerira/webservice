using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Wepa.Models
{
    public class Context : DbContext
    {
         
        public DbSet<Pais> Paises { get; set; }


    }
}