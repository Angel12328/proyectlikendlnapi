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
    public class RecomendacionController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// obtiene todas las recomendaciones registradas en el sistema.
        /// </summary>
        /// <returns></returns>
        // GET: api/Recomendacion
        public IQueryable<Recomendacion> GetRecomendaciones()
        {
            return db.Recomendaciones;
        }

        /// <summary>
        /// Obtiene una recomendación específica por su identificador único
        /// </summary>
        /// <param name="id">Identificador numérico de la recomendación</param>
        /// <returns>
        /// Respuesta HTTP con el objeto Recomendacion si existe,
        /// o código de estado 404 si no se encuentra
        /// </returns>
        /// <response code="200">Recomendación encontrada y retornada exitosamente</response>
        /// <response code="404">No existe recomendación con el ID especificado</response>
        // GET: api/Recomendacion/5
        [ResponseType(typeof(Recomendacion))]
        public async Task<IHttpActionResult> GetRecomendacion(int id)
        {
            Recomendacion recomendacion = await db.Recomendaciones.FindAsync(id);
            if (recomendacion == null)
            {
                return NotFound();
            }

            return Ok(recomendacion);
        }

        /// <summary>
        /// Actualiza una recomendación existente en el sistema
        /// </summary>
        /// <param name="id">Identificador único de la recomendación</param>
        /// <param name="recomendacion">Datos actualizados de la recomendación</param>
        /// <returns>
        /// Respuesta HTTP sin contenido en caso de éxito
        /// </returns>
        /// <response code="204">Recomendación actualizada exitosamente</response>
        /// <response code="400">Solicitud inválida (datos incorrectos o IDs no coincidentes)</response>
        /// <response code="404">Recomendación no encontrada</response>
        // PUT: api/Recomendacion/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRecomendacion(int id, Recomendacion recomendacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recomendacion.ID)
            {
                return BadRequest();
            }

            db.Entry(recomendacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecomendacionExists(id))
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
        /// Crea una nueva recomendación en el sistema
        /// </summary>
        /// <param name="recomendacion">Datos completos de la recomendación a crear</param>
        /// <returns>
        /// Respuesta HTTP con la recomendación creada y ubicación del nuevo recurso
        /// </returns>
        /// <response code="201">Recomendación creada exitosamente</response>
        /// <response code="400">Datos de recomendación inválidos o incompletos</response>
        // POST: api/Recomendacion
        [ResponseType(typeof(Recomendacion))]
        public async Task<IHttpActionResult> PostRecomendacion(Recomendacion recomendacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recomendaciones.Add(recomendacion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = recomendacion.ID }, recomendacion);
        }

        /// <summary>
        /// Elimina una recomendación específica del sistema
        /// </summary>
        /// <param name="id">Identificador único de la recomendación</param>
        /// <returns>
        /// Respuesta HTTP con la recomendación eliminada en caso de éxito,
        /// o código de error correspondiente
        /// </returns>
        /// <response code="200">Recomendación eliminada exitosamente (retorna el objeto eliminado)</response>
        /// <response code="404">No se encontró recomendación con el ID especificado</response>
        /// <response code="500">Error interno durante el proceso de eliminación</response>
        // DELETE: api/Recomendacion/5
        [ResponseType(typeof(Recomendacion))]
        public async Task<IHttpActionResult> DeleteRecomendacion(int id)
        {
            Recomendacion recomendacion = await db.Recomendaciones.FindAsync(id);
            if (recomendacion == null)
            {
                return NotFound();
            }

            db.Recomendaciones.Remove(recomendacion);
            await db.SaveChangesAsync();

            return Ok(recomendacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecomendacionExists(int id)
        {
            return db.Recomendaciones.Count(e => e.ID == id) > 0;
        }
    }
}