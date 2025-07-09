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

        // GET: api/OfertaLaboral
        public IQueryable<OfertaLaboral> GetOfertasLaborales()
        {
            return db.OfertasLaborales;
        }

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