using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaPermisos.Entities
{
    public class TipoPermiso
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }


        public ICollection<Permiso> Permisos { get; set; }
    }
}
