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
    public class NotificacionMensajeController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// Obtiene todas las notificaciones de mensajes.
        /// </summary>
        /// <returns>Una lista de notificaciones de mensajes</returns>
        // GET: api/NotificacionMensaje
        public IQueryable<NotificacionMensaje> GetNotificacionesMensajes()
        {
            return db.NotificacionesMensajes;
        }

        /// <summary>
        /// Obtiene una notificación de mensaje específica.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // GET: api/NotificacionMensaje/5
        ///
        /// </remarks>
        /// <param name="id">El id de la notificación de mensaje a obtener</param>
        /// <returns>Información de la notificación de mensaje</returns>
        /// <response code="404">Si la notificación de mensaje no fue encontrada</response>
        /// <response code="200">Si la notificación de mensaje fue encontrada</response>
        // GET: api/NotificacionMensaje/5
        [ResponseType(typeof(NotificacionMensaje))]
        public async Task<IHttpActionResult> GetNotificacionMensaje(int id)
        {
            NotificacionMensaje notificacionMensaje = await db.NotificacionesMensajes.FindAsync(id);
            if (notificacionMensaje == null)
            {
                return NotFound();
            }

            return Ok(notificacionMensaje);
        }

        /// <summary>
        /// Actualiza completamente una notificación de mensaje.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/NotificacionMensaje/5
        ///
        /// </remarks>
        /// <param name="id">El id de la notificación de mensaje a actualizar</param>
        /// <param name="notificacionMensaje">La información de la notificación de mensaje a reemplazar</param>
        /// <returns>Vacío si el proceso es exitoso</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="400">Si el id no coincide con la notificación de mensaje</response>
        /// <response code="404">Si la notificación de mensaje no fue encontrada</response>
        /// <response code="204">Si la notificación de mensaje fue actualizada</response>
        // PUT: api/NotificacionMensaje/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNotificacionMensaje(int id, NotificacionMensaje notificacionMensaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notificacionMensaje.ID)
            {
                return BadRequest();
            }

            db.Entry(notificacionMensaje).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacionMensajeExists(id))
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
        /// Crea una nueva notificación de mensaje.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // POST: api/NotificacionMensaje
        ///
        /// </remarks>
        /// <param name="notificacionMensaje">La información de la notificación de mensaje a crear</param>
        /// <returns>La notificación de mensaje recién creada</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="201">Si la notificación de mensaje fue creada exitosamente</response>
        // POST: api/NotificacionMensaje
        [ResponseType(typeof(NotificacionMensaje))]
        public async Task<IHttpActionResult> PostNotificacionMensaje(NotificacionMensaje notificacionMensaje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NotificacionesMensajes.Add(notificacionMensaje);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = notificacionMensaje.ID }, notificacionMensaje);
        }

        /// <summary>
        /// Elimina una notificación de mensaje específica.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // DELETE: api/NotificacionMensaje/5
        ///
        /// </remarks>
        /// <param name="id">El id de la notificación de mensaje a eliminar</param>
        /// <returns>La notificación de mensaje eliminada</returns>
        /// <response code="404">Si la notificación de mensaje no fue encontrada</response>
        /// <response code="200">Si la notificación de mensaje fue eliminada exitosamente</response>
        // DELETE: api/NotificacionMensaje/5
        [ResponseType(typeof(NotificacionMensaje))]
        public async Task<IHttpActionResult> DeleteNotificacionMensaje(int id)
        {
            NotificacionMensaje notificacionMensaje = await db.NotificacionesMensajes.FindAsync(id);
            if (notificacionMensaje == null)
            {
                return NotFound();
            }

            db.NotificacionesMensajes.Remove(notificacionMensaje);
            await db.SaveChangesAsync();

            return Ok(notificacionMensaje);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotificacionMensajeExists(int id)
        {
            return db.NotificacionesMensajes.Count(e => e.ID == id) > 0;
        }
    }
}