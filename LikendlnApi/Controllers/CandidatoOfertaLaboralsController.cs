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
    public class CandidatoOfertaLaboralsController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        ///     Obtiene todos los candidatos que han aplicado a ofertas laborales disponibles.
        /// </summary>
        /// <returns></returns>
        // GET: api/CandidatoOfertaLaborals
        public IQueryable<CandidatoOfertaLaboral> GetCandidatosOfertaLaborales()
        {
            return db.CandidatosOfertaLaborales;
        }

        /// <summary>
        /// Obtiene una relación específica entre candidato y oferta laboral.
        /// </summary>
        /// <remarks>
        /// Recupera los detalles completos de una postulación o relación entre un candidato y una oferta laboral,
        /// incluyendo metadatos como estado, fecha de aplicación y comentarios.
        /// </remarks>
        /// <param name="id">ID único de la relación candidato-oferta</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con la relación si existe
        /// - 404 (Not Found) si la relación no existe
        /// - 400 (Bad Request) si el ID es inválido
        /// </returns>
        /// <response code="200">Relación candidato-oferta encontrada</response>
        /// <response code="404">Relación no encontrada</response>
        /// <response code="400">ID de relación inválido</response>
        // GET: api/CandidatoOfertaLaborals/5
        [ResponseType(typeof(CandidatoOfertaLaboral))]
        public async Task<IHttpActionResult> GetCandidatoOfertaLaboral(int id)
        {
            CandidatoOfertaLaboral candidatoOfertaLaboral = await db.CandidatosOfertaLaborales.FindAsync(id);
            if (candidatoOfertaLaboral == null)
            {
                return NotFound();
            }

            return Ok(candidatoOfertaLaboral);
        }

        /// <summary>
        /// Actualiza una relación entre candidato y oferta laboral existente.
        /// </summary>
        /// <remarks>
        /// Actualiza completamente (PUT) una postulación o relación candidato-oferta laboral.
        /// Requiere que el ID en la URL coincida con el ID en el objeto proporcionado.
        /// </remarks>
        /// <param name="id">ID de la relación a actualizar</param>
        /// <param name="candidatoOfertaLaboral">Objeto con los datos actualizados</param>
        /// <returns>
        /// Retorna:
        /// - 204 (No Content) si la actualización fue exitosa
        /// - 400 (Bad Request) si:
        ///   - El modelo es inválido
        ///   - Los IDs no coinciden
        ///   - Se intenta modificar IDs de candidato/oferta
        /// - 404 (Not Found) si la relación no existe
        /// </returns>
        /// <response code="204">Actualización exitosa</response>
        /// <response code="400">Solicitud mal formada</response>
        /// <response code="404">Relación no encontrada</response>
        // PUT: api/CandidatoOfertaLaborals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoOfertaLaboral(int id, CandidatoOfertaLaboral candidatoOfertaLaboral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoOfertaLaboral.ID)
            {
                return BadRequest();
            }

            db.Entry(candidatoOfertaLaboral).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoOfertaLaboralExists(id))
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
        /// Crea una nueva relación entre candidato y oferta laboral.
        /// </summary>
        /// <remarks>
        /// Establece una nueva postulación de un candidato a una oferta laboral.
        /// Devuelve la relación creada con su ID generado.
        /// </remarks>
        /// <param name="candidatoOfertaLaboral">Datos de la nueva postulación</param>
        /// <returns>
        /// Retorna:
        /// - 201 (Created) con la postulación creada si es exitoso
        /// - 400 (Bad Request) si:
        ///   - El modelo es inválido
        ///   - Validación de negocio falla
        /// - 409 (Conflict) si ya existe la postulación
        /// - 403 (Forbidden) si no tiene permisos
        /// - 404 (Not Found) si candidato u oferta no existen
        /// </returns>
        /// <response code="201">Postulación creada exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        // POST: api/CandidatoOfertaLaborals
        [ResponseType(typeof(CandidatoOfertaLaboral))]
        public async Task<IHttpActionResult> PostCandidatoOfertaLaboral(CandidatoOfertaLaboral candidatoOfertaLaboral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatosOfertaLaborales.Add(candidatoOfertaLaboral);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoOfertaLaboral.ID }, candidatoOfertaLaboral);
        }

        /// <summary>
        /// Elimina una postulación de candidato a oferta laboral.
        /// </summary>
        /// <remarks>
        /// Elimina permanentemente una relación de postulación entre un candidato y una oferta laboral.
        /// Devuelve los datos de la postulación eliminada para confirmación.
        /// </remarks>
        /// <param name="id">ID de la postulación a eliminar</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con la postulación eliminada si es exitoso
        /// - 404 (Not Found) si la postulación no existe
        /// - 400 (Bad Request) si el ID es inválido
        /// </returns>
        /// <response code="200">Postulación eliminada exitosamente</response>
        /// <response code="404">Postulación no encontrada</response>
        /// <response code="400">ID de postulación inválido</response>
        // DELETE: api/CandidatoOfertaLaborals/5
        [ResponseType(typeof(CandidatoOfertaLaboral))]
        public async Task<IHttpActionResult> DeleteCandidatoOfertaLaboral(int id)
        {
            CandidatoOfertaLaboral candidatoOfertaLaboral = await db.CandidatosOfertaLaborales.FindAsync(id);
            if (candidatoOfertaLaboral == null)
            {
                return NotFound();
            }

            db.CandidatosOfertaLaborales.Remove(candidatoOfertaLaboral);
            await db.SaveChangesAsync();

            return Ok(candidatoOfertaLaboral);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoOfertaLaboralExists(int id)
        {
            return db.CandidatosOfertaLaborales.Count(e => e.ID == id) > 0;
        }
    }
}