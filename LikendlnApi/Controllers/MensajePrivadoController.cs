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
    public class MensajePrivadoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/MensajePrivado
        public IQueryable<MensajePrivado> GetMensajeBases()
        {
            return db.MensajesPrivados;
        }

        // GET: api/MensajePrivado/5
        [ResponseType(typeof(MensajePrivado))]
        public async Task<IHttpActionResult> GetMensajePrivado(int id)
        {
            MensajePrivado mensajePrivado = await db.MensajesPrivados.FindAsync(id);
            if (mensajePrivado == null)
            {
                return NotFound();
            }

            return Ok(mensajePrivado);
        }

        // PUT: api/MensajePrivado/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMensajePrivado(int id, MensajePrivado mensajePrivado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mensajePrivado.Id)
            {
                return BadRequest();
            }

            db.Entry(mensajePrivado).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensajePrivadoExists(id))
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

        // POST: api/MensajePrivado
        [ResponseType(typeof(MensajePrivado))]
        public async Task<IHttpActionResult> PostMensajePrivado(MensajePrivado mensajePrivado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MensajesPrivados.Add(mensajePrivado);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mensajePrivado.Id }, mensajePrivado);
        }

        // DELETE: api/MensajePrivado/5
        [ResponseType(typeof(MensajePrivado))]
        public async Task<IHttpActionResult> DeleteMensajePrivado(int id)
        {
            MensajePrivado mensajePrivado = await db.MensajesPrivados.FindAsync(id);
            if (mensajePrivado == null)
            {
                return NotFound();
            }

            db.MensajesPrivados.Remove(mensajePrivado);
            await db.SaveChangesAsync();

            return Ok(mensajePrivado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MensajePrivadoExists(int id)
        {
            return db.MensajesPrivados.Count(e => e.Id == id) > 0;
        }
    }
}