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

        // GET: api/Recomendacion
        public IQueryable<Recomendacion> GetRecomendaciones()
        {
            return db.Recomendaciones;
        }

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