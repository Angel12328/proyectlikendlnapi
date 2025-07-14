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
    public class CandidatoHabilidadController : ApiController
    {
        private  readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// Obtiene todas las habilidades de los candidatos disponibles.
        /// </summary>
        /// <returns></returns>
        // GET: api/CandidatoHabilidad
        public IQueryable<CandidatoHabilidad> GetCandidatosHabilidades()
        {
            return db.CandidatosHabilidades;
        }

        /// <summary>
        /// Obtiene una habilidad específica asociada a un candidato.
        /// </summary>
        /// <remarks>
        /// Recupera los detalles completos de una habilidad registrada para un candidato,
        /// incluyendo información de validación y nivel de competencia.
        /// </remarks>
        /// <param name="id">ID único de la relación candidato-habilidad</param>
        /// <returns>
        /// Retorna:
        /// - 200 (OK) con la habilidad del candidato si existe
        /// - 404 (Not Found) si la relación no existe
        /// - 400 (Bad Request) si el ID es inválido
        /// </returns>
        /// <response code="200">Habilidad del candidato encontrada</response>
        /// <response code="404">Relación candidato-habilidad no encontrada</response>
        /// <response code="400">ID de relación inválido</response>
        // GET: api/CandidatoHabilidad/5
        [ResponseType(typeof(CandidatoHabilidad))]
        public async Task<IHttpActionResult> GetCandidatoHabilidad(int id)
        {
            CandidatoHabilidad candidatoHabilidad = await db.CandidatosHabilidades.FindAsync(id);
            if (candidatoHabilidad == null)
            {
                return NotFound();
            }

            return Ok(candidatoHabilidad);
        }

        /// <summary>
        /// Actualiza una habilidad asociada a un candidato.
        /// </summary>
        /// <remarks>
        /// Actualiza completamente (PUT) los datos de una habilidad de candidato existente.
        /// Requiere que el ID en la URL coincida con el ID en el objeto proporcionado.
        /// </remarks>
        /// <param name="id">ID de la relación candidato-habilidad a actualizar</param>
        /// <param name="candidatoHabilidad">Objeto con los datos actualizados</param>
        /// <returns>
        /// Retorna:
        /// - 204 (No Content) si la actualización fue exitosa
        /// - 400 (Bad Request) si:
        ///   - El modelo es inválido
        ///   - Los IDs no coinciden
        ///   - Se intenta modificar IDs de candidato/habilidad
        /// - 404 (Not Found) si la relación no existe
        /// </returns>
        /// <response code="204">Actualización exitosa</response>
        /// <response code="400">Solicitud mal formada</response>
        /// <response code="404">Relación no encontrada</response>
        // PUT: api/CandidatoHabilidad/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoHabilidad(int id, CandidatoHabilidad candidatoHabilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoHabilidad.ID)
            {
                return BadRequest();
            }

            db.Entry(candidatoHabilidad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoHabilidadExists(id))
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
        /// Crea una nueva asociación de habilidad para un candidato.
        /// </summary>
        /// <remarks>
        /// Registra una nueva habilidad asociada a un candidato, incluyendo nivel de competencia y experiencia.
        /// Devuelve la relación creada con su ID generado     
        /// </remarks>
        /// <param name="candidatoHabilidad">Datos de la nueva habilidad del candidato</param>
        /// <returns>
        /// Retorna:
        /// - 201 (Created) con la habilidad creada si es exitoso
        /// - 400 (Bad Request) si:
        ///   - El modelo es inválido
        ///   - Validación de negocio falla
        /// - 404 (Not Found) si candidato o habilidad no existen
        /// </returns>
        /// <response code="201">Habilidad del candidato creada exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        /// <response code="404">Candidato o habilidad no encontrados</response>
        // POST: api/CandidatoHabilidad
        [ResponseType(typeof(CandidatoHabilidad))]
        public async Task<IHttpActionResult> PostCandidatoHabilidad(CandidatoHabilidad candidatoHabilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatosHabilidades.Add(candidatoHabilidad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoHabilidad.ID }, candidatoHabilidad);
        }

        /// <summary>
        /// Elimina una relación entre un candidato y una habilidad específica de la base de datos.
        /// </summary>
        /// <param name="id">El ID de la relación CandidatoHabilidad que se desea eliminar.</param>
        /// <returns>
        /// Retorna un resultado HTTP:
        /// - 200 OK con el objeto eliminado si la operación es exitosa
        /// - 404 Not Found si no se encuentra la relación con el ID especificado
        /// </returns>
        /// <response code="200">Retorna el objeto CandidatoHabilidad eliminado</response>
        /// <response code="404">Si no se encuentra la relación con el ID especificado</response>
        // DELETE: api/CandidatoHabilidad/5
        [ResponseType(typeof(CandidatoHabilidad))]
        public async Task<IHttpActionResult> DeleteCandidatoHabilidad(int id)
        {
            CandidatoHabilidad candidatoHabilidad = await db.CandidatosHabilidades.FindAsync(id);
            if (candidatoHabilidad == null)
            {
                return NotFound();
            }

            db.CandidatosHabilidades.Remove(candidatoHabilidad);
            await db.SaveChangesAsync();

            return Ok(candidatoHabilidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoHabilidadExists(int id)
        {
            return db.CandidatosHabilidades.Count(e => e.ID == id) > 0;
        }
    }
}