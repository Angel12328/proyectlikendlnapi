using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LikendlnApi.Models;

namespace LikendlnApi.Controllers
{
    public class MiembroGrupoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// Obtiene todos los miembros de grupos.
        /// </summary>
        /// <returns>Una lista de miembros de grupos</returns>
        // GET: api/MiembroGrupo
        public IQueryable<MiembroGrupo> GetMiembrosGrupos()
        {
            return db.MiembrosGrupos;
        }

        /// <summary>
        /// Obtiene un miembro de grupo específico.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // GET: api/MiembroGrupo/5
        ///
        /// </remarks>
        /// <param name="id">El id del miembro de grupo a obtener</param>
        /// <returns>Información del miembro de grupo</returns>
        /// <response code="404">Si el miembro de grupo no fue encontrado</response>
        /// <response code="200">Si el miembro de grupo fue encontrado</response>
        // GET: api/MiembroGrupo/5
        [ResponseType(typeof(MiembroGrupo))]
        public async Task<IHttpActionResult> GetMiembroGrupo(int id)
        {
            MiembroGrupo miembroGrupo = await db.MiembrosGrupos.FindAsync(id);
            if (miembroGrupo == null)
            {
                return NotFound();
            }

            return Ok(miembroGrupo);
        }

        /// <summary>
        /// Actualiza completamente un miembro de grupo.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/MiembroGrupo/5
        ///
        /// </remarks>
        /// <param name="id">El id del miembro de grupo a actualizar</param>
        /// <param name="miembroGrupo">La información del miembro de grupo a reemplazar</param>
        /// <returns>Vacío si el proceso es exitoso</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="400">Si el id no coincide con el miembro de grupo</response>
        /// <response code="404">Si el miembro de grupo no fue encontrado</response>
        /// <response code="204">Si el miembro de grupo fue actualizado</response>
        // PUT: api/MiembroGrupo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMiembroGrupo(int id, MiembroGrupo miembroGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != miembroGrupo.ID)
            {
                return BadRequest();
            }

            db.Entry(miembroGrupo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiembroGrupoExists(id))
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

        /// <summary>
        /// Crea un nuevo miembro de grupo.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // POST: api/MiembroGrupo
        ///
        /// </remarks>
        /// <param name="miembroGrupo">La información del miembro de grupo a crear</param>
        /// <returns>El miembro de grupo recién creado</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="201">Si el miembro de grupo fue creado exitosamente</response>
        // POST: api/MiembroGrupo
        [ResponseType(typeof(MiembroGrupo))]
        public async Task<IHttpActionResult> PostMiembroGrupo(MiembroGrupo miembroGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MiembrosGrupos.Add(miembroGrupo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = miembroGrupo.ID }, miembroGrupo);
        }

        /// <summary>
        /// Elimina un miembro de grupo específico.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // DELETE: api/MiembroGrupo/5
        ///
        /// </remarks>
        /// <param name="id">El id del miembro de grupo a eliminar</param>
        /// <returns>El miembro de grupo eliminado</returns>
        /// <response code="404">Si el miembro de grupo no fue encontrado</response>
        /// <response code="200">Si el miembro de grupo fue eliminado exitosamente</response>
        // DELETE: api/MiembroGrupo/5
        [ResponseType(typeof(MiembroGrupo))]
        public async Task<IHttpActionResult> DeleteMiembroGrupo(int id)
        {
            MiembroGrupo miembroGrupo = await db.MiembrosGrupos.FindAsync(id);
            if (miembroGrupo == null)
            {
                return NotFound();
            }

            db.MiembrosGrupos.Remove(miembroGrupo);
            await db.SaveChangesAsync();

            return Ok(miembroGrupo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MiembroGrupoExists(int id)
        {
            return db.MiembrosGrupos.Count(e => e.ID == id) > 0;
        }
    }
}