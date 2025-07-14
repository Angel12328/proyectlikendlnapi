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
    public class PublicacionController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// Obtiene todas las publicaciones.
        /// </summary>
        /// <returns>Una lista de publicaciones</returns>
        // GET: api/Publicacion
        public IQueryable<Publicacion> GetPublicaciones()
        {
            return db.Publicaciones;
        }

        /// <summary>
        /// Obtiene una publicación específica.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // GET: api/Publicacion/5
        ///
        /// </remarks>
        /// <param name="id">El id de la publicación a obtener</param>
        /// <returns>Información de la publicación</returns>
        /// <response code="404">Si la publicación no fue encontrada</response>
        /// <response code="200">Si la publicación fue encontrada</response>
        // GET: api/Publicacion/5
        [ResponseType(typeof(Publicacion))]
        public async Task<IHttpActionResult> GetPublicacion(int id)
        {
            Publicacion publicacion = await db.Publicaciones.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }

            return Ok(publicacion);
        }

        /// <summary>
        /// Actualiza completamente una publicación.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/Publicacion/5
        ///
        /// </remarks>
        /// <param name="id">El id de la publicación a actualizar</param>
        /// <param name="publicacion">La información de la publicación a reemplazar</param>
        /// <returns>Vacío si el proceso es exitoso</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="400">Si el id no coincide con la publicación</response>
        /// <response code="404">Si la publicación no fue encontrada</response>
        /// <response code="204">Si la publicación fue actualizada</response>
        // PUT: api/Publicacion/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPublicacion(int id, Publicacion publicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publicacion.Id)
            {
                return BadRequest();
            }

            db.Entry(publicacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionExists(id))
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
        /// Crea una nueva publicación.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // POST: api/Publicacion
        ///
        /// </remarks>
        /// <param name="publicacion">La información de la publicación a crear</param>
        /// <returns>La publicación recién creada</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="201">Si la publicación fue creada exitosamente</response>
        // POST: api/Publicacion
        [ResponseType(typeof(Publicacion))]
        public async Task<IHttpActionResult> PostPublicacion(Publicacion publicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Publicaciones.Add(publicacion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = publicacion.Id }, publicacion);
        }

        /// <summary>
        /// Elimina una publicación específica.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // DELETE: api/Publicacion/5
        ///
        /// </remarks>
        /// <param name="id">El id de la publicación a eliminar</param>
        /// <returns>La publicación eliminada</returns>
        /// <response code="404">Si la publicación no fue encontrada</response>
        /// <response code="200">Si la publicación fue eliminada exitosamente</response>
        // DELETE: api/Publicacion/5
        [ResponseType(typeof(Publicacion))]
        public async Task<IHttpActionResult> DeletePublicacion(int id)
        {
            Publicacion publicacion = await db.Publicaciones.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }

            db.Publicaciones.Remove(publicacion);
            await db.SaveChangesAsync();

            return Ok(publicacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PublicacionExists(int id)
        {
            return db.Publicaciones.Count(e => e.Id == id) > 0;
        }
    }
}