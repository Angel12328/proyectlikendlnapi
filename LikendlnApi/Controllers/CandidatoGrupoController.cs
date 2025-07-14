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
    public class CandidatoGrupoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        ///     obtiene todos los grupos a los que un candidato pertenece disponibles.
        /// </summary>
        /// <returns></returns>
        // GET: api/CandidatoGrupo
        public IQueryable<CandidatoGrupo> GetCandidatosGrupos()
        {
            return db.CandidatosGrupos;
        }

        /// <summary>
        /// Obtiene la relación entre un candidato y un grupo específico por su ID.
        /// </summary>
        /// <param name="id">ID de la relación CandidatoGrupo que se desea recuperar</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 200 OK con el objeto CandidatoGrupo si se encuentra
        /// - 404 Not Found si no existe una relación con el ID especificado
        /// </returns>
        /// <remarks>
        /// Ejemplo de solicitud:
        /// GET /api/CandidatoGrupo/5
        /// </remarks>
        /// <response code="200">Retorna el objeto CandidatoGrupo solicitado</response>
        /// <response code="404">Si no se encuentra ninguna relación con el ID proporcionado</response>
        // GET: api/CandidatoGrupo/5
        [ResponseType(typeof(CandidatoGrupo))]
        public async Task<IHttpActionResult> GetCandidatoGrupo(int id)
        {
            CandidatoGrupo candidatoGrupo = await db.CandidatosGrupos.FindAsync(id);
            if (candidatoGrupo == null)
            {
                return NotFound();
            }

            return Ok(candidatoGrupo);
        }

        /// <summary>
        /// Actualiza la relación entre un candidato y un grupo existente.
        /// </summary>
        /// <param name="id">ID de la relación CandidatoGrupo que se desea actualizar</param>
        /// <param name="candidatoGrupo">Objeto CandidatoGrupo con los nuevos datos</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 204 No Content si la actualización fue exitosa
        /// - 400 Bad Request si el modelo es inválido o los IDs no coinciden
        /// - 404 Not Found si no existe la relación con el ID especificado
        /// <returns>
        /// </remarks>
        /// <response code="204">La actualización se realizó correctamente</response>
        /// <response code="400">Si el modelo es inválido o hay discrepancia en los IDs</response>
        /// <response code="404">Si no se encuentra la relación a actualizar</response>
        // PUT: api/CandidatoGrupo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoGrupo(int id, CandidatoGrupo candidatoGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoGrupo.ID)
            {
                return BadRequest();
            }

            db.Entry(candidatoGrupo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoGrupoExists(id))
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
        /// Crea una nueva relación entre un candidato y un grupo.
        /// </summary>
        /// <param name="candidatoGrupo">Objeto CandidatoGrupo con los datos de la nueva relación</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 201 Created con la nueva relación creada y su ubicación
        /// - 400 Bad Request si el modelo es inválido
        /// <returns>
        /// </remarks>
        /// <response code="201">Retorna el objeto CandidatoGrupo recién creado con su URL de acceso</response>
        /// <response code="400">Si el modelo recibido es inválido o faltan datos requeridos</response>
        // POST: api/CandidatoGrupo
        [ResponseType(typeof(CandidatoGrupo))]
        public async Task<IHttpActionResult> PostCandidatoGrupo(CandidatoGrupo candidatoGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatosGrupos.Add(candidatoGrupo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoGrupo.ID }, candidatoGrupo);
        }

        /// <summary>
        /// Elimina una relación específica entre candidato y grupo según su ID.
        /// </summary>
        /// <param name="id">ID de la relación CandidatoGrupo que se desea eliminar</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 200 OK con la relación eliminada si la operación fue exitosa
        /// - 404 Not Found si no se encuentra la relación con el ID especificado
        /// </returns>
        /// <remarks>
        /// Ejemplo de solicitud:
        /// DELETE /api/CandidatoGrupo/5
        /// </remarks>
        /// <response code="200">Retorna el objeto CandidatoGrupo eliminado</response>
        /// <response code="404">Si no existe ninguna relación con el ID proporcionado</response>
        // DELETE: api/CandidatoGrupo/5
        [ResponseType(typeof(CandidatoGrupo))]
        public async Task<IHttpActionResult> DeleteCandidatoGrupo(int id)
        {
            CandidatoGrupo candidatoGrupo = await db.CandidatosGrupos.FindAsync(id);
            if (candidatoGrupo == null)
            {
                return NotFound();
            }

            db.CandidatosGrupos.Remove(candidatoGrupo);
            await db.SaveChangesAsync();

            return Ok(candidatoGrupo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoGrupoExists(int id)
        {
            return db.CandidatosGrupos.Count(e => e.ID == id) > 0;
        }
    }
}