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

        // GET: api/NotificacionMensaje
        public IQueryable<NotificacionMensaje> GetNotificacionesMensajes()
        {
            return db.NotificacionesMensajes;
        }

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