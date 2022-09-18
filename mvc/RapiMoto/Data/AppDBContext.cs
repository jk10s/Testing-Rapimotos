using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

namespace RapiMoto.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<HistorialCliente> HistorialCliente { get; set; }
        public DbSet<HitorialTecnico> HitorialTecnico { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Tecnico> Tecnico { get; set; }
        public DbSet<TipoServicio> TipoServicio { get; set; }
        
    }
}