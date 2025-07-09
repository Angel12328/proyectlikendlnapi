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

        // GET: api/Habilidad
        public IQueryable<Habilidad> GetHabilidades()
        {
            return db.Habilidades;
        }

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