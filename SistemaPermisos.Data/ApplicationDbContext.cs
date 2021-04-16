using Microsoft.EntityFrameworkCore;
using SistemaPermisos.Data.Mapping;
using SistemaPermisos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPermisos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PermisoMap());
            builder.ApplyConfiguration(new TipoPermisoMap());

            base.OnModelCreating(builder);
        }

        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<TipoPermiso> TiposPermisos { get; set; }
    }
}
