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
    public class HabilidadController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// Obtiene todas las habilidades.
        /// </summary>
        /// <returns>Una lista de habilidades</returns>
        // GET: api/Habilidad
        public IQueryable<Habilidad> GetHabilidades()
        {
            return db.Habilidades;
        }

        /// <summary>
        /// Obtiene una habilidad.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // GET: api/Habilidad/5
        ///
        /// </remarks>
        /// <param name="id">El id de la habilidad a obtener.</param>
        /// <returns>La información de una habilidad</returns>
        /// <response code="404">Si la habilidad no fue encontrada</response>
        /// <response code="200">Si la habilidad fue encontrada</response>
        // GET: api/Habilidad/5
        [ResponseType(typeof(Habilidad))]
        public async Task<IHttpActionResult> GetHabilidad(int id)
        {
            Habilidad habilidad = await db.Habilidades.FindAsync(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            return Ok(habilidad);
        }

        /// <summary>
        /// Actualiza completamente una habilidad.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/Habilidad/5
        ///
        /// </remarks>
        /// <param name="id">El id de la habilidad a actualizar.</param>
        /// <param name="habilidad">La información de la habilidad a reemplazar</param>
        /// <returns>Vacio si el proceso es hecho con éxito</returns>
        /// <response code="400">Los datos ingresados no están completos</response>
        /// <response code="400">Si el id a actualizar no coincide con el id de información a modificar</response>
        /// <response code="404">Si la habilidad a modificar no fue encontrada</response>
        /// <response code="204">Si la habilidad fue modificada</response>
        // PUT: api/Habilidad/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHabilidad(int id, Habilidad habilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != habilidad.ID)
            {
                return BadRequest();
            }

            db.Entry(habilidad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabilidadExists(id))
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
        /// Crea una nueva habilidad.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // POST: api/Habilidad
        ///
        /// </remarks>
        /// <param name="habilidad">La información de la habilidad a crear</param>
        /// <response code="400">Los datos ingresados no están completos</response>
        /// <response code="201">Si la habilidad fue creada</response>
        // POST: api/Habilidad
        [ResponseType(typeof(Habilidad))]
        public async Task<IHttpActionResult> PostHabilidad(Habilidad habilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Habilidades.Add(habilidad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = habilidad.ID }, habilidad);
        }

        /// <summary>
        /// Elimina una habilidad.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // DELETE: api/Habilidad/5
        ///
        /// </remarks>
        /// <param name="id">El id de la habilidad a eliminar.</param>
        /// <returns>La información de la habilidad eliminada</returns>
        /// <response code="404">Si la habilidad a eliminar no fue encontrada</response>
        /// <response code="200">Si la habilidad fue eliminada</response>
        // DELETE: api/Habilidad/5
        [ResponseType(typeof(Habilidad))]
        public async Task<IHttpActionResult> DeleteHabilidad(int id)
        {
            Habilidad habilidad = await db.Habilidades.FindAsync(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            db.Habilidades.Remove(habilidad);
            await db.SaveChangesAsync();

            return Ok(habilidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HabilidadExists(int id)
        {
            return db.Habilidades.Count(e => e.ID == id) > 0;
        }
    }
}