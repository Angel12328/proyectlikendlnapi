using LikendlnApi.Models;
using LikendlnApi.Models.DtoEmpresa;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LikendlnApi.Controllers
{
    public class EmpresaController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/Empresa
        public IQueryable<EmpresaDto> GetEmpresas()
        {
            return db.Empresas.Select(e => new EmpresaDto
            {
                ID = e.ID,
                NombreEmpresa = e.NombreEmpresa,
                Correo = e.CorreoElectronico,
                SitioWeb = e.SitioWeb,
                Descripcion = e.Descripcion,
                IdUsuario = e.IdUsuario
            });
        }

        // GET: api/Empresa/5
        [ResponseType(typeof(EmpresaDto))]
        public async Task<IHttpActionResult> GetEmpresa(int id)
        {
            Empresa empresa = await db.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            var dto = new EmpresaDto
            {
                ID = empresa.ID,
                NombreEmpresa = empresa.NombreEmpresa,
                Correo = empresa.CorreoElectronico,
                SitioWeb = empresa.SitioWeb,
                Descripcion = empresa.Descripcion,
                IdUsuario = empresa.IdUsuario
            };

            return Ok(dto);
        }

        // PUT: api/Empresa/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpresa(int id, CrearEmpresaDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Empresa empresa = await db.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            empresa.NombreEmpresa = dto.NombreEmpresa;
            empresa.CorreoElectronico = dto.Correo;
            empresa.SitioWeb = dto.SitioWeb;
            empresa.Descripcion = dto.Descripcion;
            empresa.IdUsuario = dto.IdUsuario;

            db.Entry(empresa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empresa
        [HttpPost]
        [ResponseType(typeof(EmpresaDto))]
        public async Task<IHttpActionResult> PostEmpresa(CrearEmpresaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos");

            var nueva = new Empresa
            {
                IdUsuario = dto.IdUsuario,
                NombreEmpresa = dto.NombreEmpresa,
                CorreoElectronico = dto.Correo,
                SitioWeb = dto.SitioWeb,
                Descripcion = dto.Descripcion,
                FechaCreacion = DateTime.Now
            };

            db.Empresas.Add(nueva);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            var resultDto = new EmpresaDto
            {
                ID = nueva.ID,
                NombreEmpresa = nueva.NombreEmpresa,
                Correo = nueva.CorreoElectronico,
                SitioWeb = nueva.SitioWeb,
                Descripcion = nueva.Descripcion,
                IdUsuario = nueva.IdUsuario
            };

            return CreatedAtRoute("DefaultApi", new { id = nueva.ID }, resultDto);
        }

        // DELETE: api/Empresa/5
        [ResponseType(typeof(EmpresaDto))]
        public async Task<IHttpActionResult> DeleteEmpresa(int id)
        {
            Empresa empresa = await db.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            db.Empresas.Remove(empresa);
            await db.SaveChangesAsync();

            return Ok(new EmpresaDto
            {
                ID = empresa.ID,
                NombreEmpresa = empresa.NombreEmpresa,
                Correo = empresa.CorreoElectronico,
                SitioWeb = empresa.SitioWeb,
                Descripcion = empresa.Descripcion,
                IdUsuario = empresa.IdUsuario
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpresaExists(int id)
        {
            return db.Empresas.Any(e => e.ID == id);
        }
    }
}
