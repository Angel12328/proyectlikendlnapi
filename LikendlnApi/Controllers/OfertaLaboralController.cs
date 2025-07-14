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
    public class OfertaLaboralController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// Obtiene todas las ofertas laborales.
        /// </summary>
        /// <returns>Una lista de ofertas laborales</returns>
        // GET: api/OfertaLaboral
        public IQueryable<OfertaLaboral> GetOfertasLaborales()
        {
            return db.OfertasLaborales;
        }

        /// <summary>
        /// Obtiene una oferta laboral específica.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // GET: api/OfertaLaboral/5
        ///
        /// </remarks>
        /// <param name="id">El id de la oferta laboral a obtener</param>
        /// <returns>Información de la oferta laboral</returns>
        /// <response code="404">Si la oferta laboral no fue encontrada</response>
        /// <response code="200">Si la oferta laboral fue encontrada</response>
        // GET: api/OfertaLaboral/5
        [ResponseType(typeof(OfertaLaboral))]
        public async Task<IHttpActionResult> GetOfertaLaboral(int id)
        {
            OfertaLaboral ofertaLaboral = await db.OfertasLaborales.FindAsync(id);
            if (ofertaLaboral == null)
            {
                return NotFound();
            }

            return Ok(ofertaLaboral);
        }

        /// <summary>
        /// Actualiza completamente una oferta laboral.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/OfertaLaboral/5
        ///
        /// </remarks>
        /// <param name="id">El id de la oferta laboral a actualizar</param>
        /// <param name="ofertaLaboral">La información de la oferta laboral a reemplazar</param>
        /// <returns>Vacío si el proceso es exitoso</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="400">Si el id no coincide con la oferta laboral</response>
        /// <response code="404">Si la oferta laboral no fue encontrada</response>
        /// <response code="204">Si la oferta laboral fue actualizada</response>
        // PUT: api/OfertaLaboral/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOfertaLaboral(int id, OfertaLaboral ofertaLaboral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ofertaLaboral.ID)
            {
                return BadRequest();
            }

            db.Entry(ofertaLaboral).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaLaboralExists(id))
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
        /// Crea una nueva oferta laboral.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // POST: api/OfertaLaboral
        ///
        /// </remarks>
        /// <param name="ofertaLaboral">La información de la oferta laboral a crear</param>
        /// <returns>La oferta laboral recién creada</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="201">Si la oferta laboral fue creada exitosamente</response>
        // POST: api/OfertaLaboral
        [ResponseType(typeof(OfertaLaboral))]
        public async Task<IHttpActionResult> PostOfertaLaboral(OfertaLaboral ofertaLaboral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OfertasLaborales.Add(ofertaLaboral);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ofertaLaboral.ID }, ofertaLaboral);
        }

        /// <summary>
        /// Elimina una oferta laboral específica.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // DELETE: api/OfertaLaboral/5
        ///
        /// </remarks>
        /// <param name="id">El id de la oferta laboral a eliminar</param>
        /// <returns>La oferta laboral eliminada</returns>
        /// <response code="404">Si la oferta laboral no fue encontrada</response>
        /// <response code="200">Si la oferta laboral fue eliminada exitosamente</response>
        // DELETE: api/OfertaLaboral/5
        [ResponseType(typeof(OfertaLaboral))]
        public async Task<IHttpActionResult> DeleteOfertaLaboral(int id)
        {
            OfertaLaboral ofertaLaboral = await db.OfertasLaborales.FindAsync(id);
            if (ofertaLaboral == null)
            {
                return NotFound();
            }

            db.OfertasLaborales.Remove(ofertaLaboral);
            await db.SaveChangesAsync();

            return Ok(ofertaLaboral);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfertaLaboralExists(int id)
        {
            return db.OfertasLaborales.Count(e => e.ID == id) > 0;
        }
    }
}