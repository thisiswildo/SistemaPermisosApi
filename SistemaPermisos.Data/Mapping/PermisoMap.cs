using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPermisos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPermisos.Data.Mapping
{
    public class PermisoMap : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable(nameof(Permiso))
                .HasKey(x => x.Id);
        }
    }
}
