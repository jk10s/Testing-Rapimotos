using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppRapiMotos.Models;

namespace AppRapiMotos.Data
{
    public class AppDBContext  : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Contacto>? Contacto {get; set; }
        
    }
}