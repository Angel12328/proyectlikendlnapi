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
    public class CandidatoSeguidorCandidatoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        ///     obtiene todos los seguidores de candidatos disponibles.
        /// </summary>
        /// <returns></returns>
        // GET: api/CandidatoSeguidorCandidato
        public IQueryable<CandidatoSeguidorCandidato> GetCandidatoSeguidoresCandidatos()
        {
            return db.CandidatoSeguidoresCandidatos;
        }

        /// <summary>
        /// Obtiene una relación de seguimiento entre candidatos específica.
        /// </summary>
        /// <remarks>
        /// Recupera los detalles completos de una relación donde un candidato sigue a otro candidato,
        /// identificada por su ID único. 
        /// </remarks>
        /// <param name="id">ID único de la relación de seguimiento</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con la relación si existe
        /// - 404 (Not Found) si la relación no existe
        /// - 400 (Bad Request) si el ID es inválido
        /// </returns>
        /// <response code="200">Relación encontrada y devuelta</response>
        /// <response code="404">No se encontró la relación especificada</response>
        /// <response code="400">ID de relación inválido</response>
        // GET: api/CandidatoSeguidorCandidato/5
        [ResponseType(typeof(CandidatoSeguidorCandidato))]
        public async Task<IHttpActionResult> GetCandidatoSeguidorCandidato(int id)
        {
            CandidatoSeguidorCandidato candidatoSeguidorCandidato = await db.CandidatoSeguidoresCandidatos.FindAsync(id);
            if (candidatoSeguidorCandidato == null)
            {
                return NotFound();
            }

            return Ok(candidatoSeguidorCandidato);
        }

        /// <summary>
        /// Actualiza una relación de seguimiento entre candidatos existente.
        /// </summary>
        /// <remarks>
        /// Realiza una actualización completa (PUT) de una relación de seguimiento entre candidatos.
        /// Requiere que el ID en la URL coincida con el ID en el objeto proporcionado.
        /// </remarks>
        /// <param name="id">ID de la relación a actualizar</param>
        /// <param name="candidatoSeguidorCandidato">Objeto con los datos actualizados</param>
        /// <returns>
        /// Retorna:
        /// - 204 (No Content) si la actualización fue exitosa
        /// - 400 (Bad Request) si:
        ///   - El modelo es inválido
        ///   - Los IDs no coinciden
        ///   - Se intenta modificar IDs de candidatos
        /// - 404 (Not Found) si la relación no existe
        /// </returns>
        /// <response code="204">Actualización exitosa</response>
        /// <response code="400">Solicitud mal formada</response>
        /// <response code="404">Relación no encontrada</response>
        // PUT: api/CandidatoSeguidorCandidato/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoSeguidorCandidato(int id, CandidatoSeguidorCandidato candidatoSeguidorCandidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoSeguidorCandidato.Id)
            {
                return BadRequest();
            }

            db.Entry(candidatoSeguidorCandidato).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoSeguidorCandidatoExists(id))
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
        /// Crea una nueva relación de seguimiento entre candidatos.
        /// </summary>
        /// <remarks>
        /// Establece una nueva relación donde un candidato sigue a otro candidato.
        /// Devuelve la relación creada con su ID generado.
        /// </remarks>
        /// <param name="candidatoSeguidorCandidato">Datos de la nueva relación</param>
        /// <returns>
        /// Retorna:
        /// - 201 (Created) con la relación creada si es exitoso
        /// - 400 (Bad Request) si:
        ///   - El modelo es inválido
        ///   - Validación de negocio falla
        /// - 404 (Not Found) si los candidatos no existen
        /// </returns>
        /// <response code="201">Relación creada exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        /// <response code="404">Uno de los candidatos no existe</response>
        // POST: api/CandidatoSeguidorCandidato
        [ResponseType(typeof(CandidatoSeguidorCandidato))]
        public async Task<IHttpActionResult> PostCandidatoSeguidorCandidato(CandidatoSeguidorCandidato candidatoSeguidorCandidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatoSeguidoresCandidatos.Add(candidatoSeguidorCandidato);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoSeguidorCandidato.Id }, candidatoSeguidorCandidato);
        }

        /// <summary>
        /// Elimina una relación de seguimiento entre candidatos.
        /// </summary>
        /// <remarks>
        /// Elimina permanentemente una relación de seguimiento entre candidatos identificada por su ID.
        /// Devuelve los datos de la relación eliminada para confirmación
        /// </remarks>
        /// <param name="id">ID de la relación a eliminar</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con la relación eliminada si es exitoso
        /// - 404 (Not Found) si la relación no existe
        /// </returns>
        /// <response code="200">Relación eliminada exitosamente</response>
        /// <response code="404">Relación no encontrada</response>
        // DELETE: api/CandidatoSeguidorCandidato/5
        [ResponseType(typeof(CandidatoSeguidorCandidato))]
        public async Task<IHttpActionResult> DeleteCandidatoSeguidorCandidato(int id)
        {
            CandidatoSeguidorCandidato candidatoSeguidorCandidato = await db.CandidatoSeguidoresCandidatos.FindAsync(id);
            if (candidatoSeguidorCandidato == null)
            {
                return NotFound();
            }

            db.CandidatoSeguidoresCandidatos.Remove(candidatoSeguidorCandidato);
            await db.SaveChangesAsync();

            return Ok(candidatoSeguidorCandidato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoSeguidorCandidatoExists(int id)
        {
            return db.CandidatoSeguidoresCandidatos.Count(e => e.Id == id) > 0;
        }
    }
}