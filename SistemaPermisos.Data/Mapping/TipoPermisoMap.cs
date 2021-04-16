using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPermisos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPermisos.Data.Mapping
{
    public class TipoPermisoMap : IEntityTypeConfiguration<TipoPermiso>
    {
        public void Configure(EntityTypeBuilder<TipoPermiso> builder)
        {
            builder.ToTable(nameof(TipoPermiso))
                .HasKey(x => x.Id);
        }
    }
}
