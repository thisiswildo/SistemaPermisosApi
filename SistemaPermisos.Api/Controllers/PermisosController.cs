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
    [Route("api/permisos")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PermisosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetPermisos()
        {
            return Ok(await _context.Permisos
                .AsNoTracking()
                // We are not supposed to share our raw data model,
                // so we only select the properties that we wanna shared,
                // also we should create a Data Transfer Object (DTO) to resolve this
                // but for this test is fine
                .Select(permiso => new 
                {
                    permiso.ApellidosEmpleado,
                    permiso.FechaPermiso,
                    permiso.Id,
                    permiso.NombreEmpleado,
                    permiso.TipoPermisoId,
                    TipoPermisoDescripcion = permiso.TipoPermiso.Descripcion
                })
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPermiso(int id)
        {
            var permiso = await _context
                .Permisos
                .AsNoTracking()
                .Where(permiso => permiso.Id == id)
                // We are not supposed to share our raw data model,
                // so we only select the properties that we wanna shared,
                // also we should create a Data Transfer Object (DTO) to resolve this
                // but for this test is fine
                .Select(permiso => new
                {
                    permiso.ApellidosEmpleado,
                    permiso.FechaPermiso,
                    permiso.Id,
                    permiso.NombreEmpleado,
                    permiso.TipoPermisoId
                })
                .FirstOrDefaultAsync();

            if (permiso == null) return NotFound();

            return Ok(permiso);
        }

        [HttpPost]
        public async Task<ActionResult> PostPermiso(Permiso permiso)
        {
            _context.Permisos.Add(new Permiso
            {
                ApellidosEmpleado = permiso.ApellidosEmpleado.Trim(),
                FechaPermiso = permiso.FechaPermiso,
                NombreEmpleado = permiso.NombreEmpleado.Trim(),
                TipoPermisoId = permiso.TipoPermisoId
            });

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutPermiso(int id, Permiso model)
        {
            if (id != model.Id) return BadRequest();

            var permiso = await _context.Permisos
                .Where(permiso => permiso.Id == id)
                .FirstOrDefaultAsync();

            if (permiso == null) return NotFound();

            permiso.ApellidosEmpleado = model.ApellidosEmpleado.Trim();
            permiso.FechaPermiso = model.FechaPermiso;
            permiso.NombreEmpleado = model.NombreEmpleado.Trim();
            permiso.TipoPermisoId = model.TipoPermisoId;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePermiso(int id)
        {
            var permiso = await _context.Permisos
                .Where(permiso => permiso.Id == id)
                .FirstOrDefaultAsync();

            if (permiso == null) return NotFound();

            _context.Permisos.Remove(permiso);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
