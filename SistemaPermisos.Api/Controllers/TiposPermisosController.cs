using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPermisos.Data;
using SistemaPermisos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPermisos.Api.Controllers
{
    [Route("api/tipos-permisos")]
    [ApiController]
    public class TiposPermisosController : ControllerBase
    {
        public ApplicationDbContext _context { get; set; }

        public TiposPermisosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPermiso>>> GetTiposPermisos()
        {
            return await _context.TiposPermisos
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPermiso>> GetTipoPermiso(int id)
        {
            var permiso = await _context.TiposPermisos
                .FirstOrDefaultAsync(permiso => permiso.Id == id);

            if (permiso == null) return NotFound();

            return permiso;
        }
    }
}
