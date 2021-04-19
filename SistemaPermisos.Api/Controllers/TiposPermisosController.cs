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
        private readonly ApplicationDbContext _context;

        public TiposPermisosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPermiso>>> GetTiposPermisos()
        {
            return Ok(await _context.TiposPermisos
                .AsNoTracking()
                // We are not supposed to share our raw data model,
                // so we only select the properties that we wanna shared,
                // also we should create a Data Transfer Object (DTO) to resolve this
                // but for this test is fine
                .Select(tipoPermiso => new 
                {
                    tipoPermiso.Id,
                    tipoPermiso.Descripcion
                })
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPermiso>> GetTipoPermiso(int id)
        {
            var tipoPermiso = await _context.TiposPermisos
                .AsNoTracking()
                .Where(tipoPermiso => tipoPermiso.Id == id)
                // We are not supposed to share our raw data model,
                // so we only select the properties that we wanna shared,
                // also we should create a Data Transfer Object (DTO) to resolve this
                // but for this test is fine
                .Select(tipoPermiso => new
                {
                    tipoPermiso.Id,
                    tipoPermiso.Descripcion
                })
                .FirstOrDefaultAsync();

            if (tipoPermiso == null) return NotFound();

            return Ok(tipoPermiso);
        }
    }
}
