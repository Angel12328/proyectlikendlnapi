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
    public class ComentarioController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/Comentario
        public IQueryable<Comentario> GetComentarios()
        {
            return db.Comentarios;
        }

        // GET: api/Comentario/5
        [ResponseType(typeof(Comentario))]
        public async Task<IHttpActionResult> GetComentario(int id)
        {
            Comentario comentario = await db.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario);
        }

        // PUT: api/Comentario/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComentario(int id, Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comentario.ID)
            {
                return BadRequest();
            }

            db.Entry(comentario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
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

        // POST: api/Comentario
        [ResponseType(typeof(Comentario))]
        public async Task<IHttpActionResult> PostComentario(Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comentarios.Add(comentario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = comentario.ID }, comentario);
        }

        // DELETE: api/Comentario/5
        [ResponseType(typeof(Comentario))]
        public async Task<IHttpActionResult> DeleteComentario(int id)
        {
            Comentario comentario = await db.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            db.Comentarios.Remove(comentario);
            await db.SaveChangesAsync();

            return Ok(comentario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComentarioExists(int id)
        {
            return db.Comentarios.Count(e => e.ID == id) > 0;
        }
    }
}