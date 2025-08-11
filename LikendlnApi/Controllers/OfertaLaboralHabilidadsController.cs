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
    public class OfertaLaboralHabilidadsController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/OfertaLaboralHabilidads
        public IQueryable<OfertaLaboralHabilidad> GetOfertasLaboralesHabilidades()
        {
            return db.OfertasLaboralesHabilidades;
        }

        // GET: api/OfertaLaboralHabilidads/5
        [ResponseType(typeof(OfertaLaboralHabilidad))]
        public async Task<IHttpActionResult> GetOfertaLaboralHabilidad(int id)
        {
            OfertaLaboralHabilidad ofertaLaboralHabilidad = await db.OfertasLaboralesHabilidades.FindAsync(id);
            if (ofertaLaboralHabilidad == null)
            {
                return NotFound();
            }

            return Ok(ofertaLaboralHabilidad);
        }

        // PUT: api/OfertaLaboralHabilidads/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOfertaLaboralHabilidad(int id, OfertaLaboralHabilidad ofertaLaboralHabilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ofertaLaboralHabilidad.ID)
            {
                return BadRequest();
            }

            db.Entry(ofertaLaboralHabilidad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaLaboralHabilidadExists(id))
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

        // POST: api/OfertaLaboralHabilidads
        [ResponseType(typeof(OfertaLaboralHabilidad))]
        public async Task<IHttpActionResult> PostOfertaLaboralHabilidad(OfertaLaboralHabilidad ofertaLaboralHabilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OfertasLaboralesHabilidades.Add(ofertaLaboralHabilidad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ofertaLaboralHabilidad.ID }, ofertaLaboralHabilidad);
        }

        // DELETE: api/OfertaLaboralHabilidads/5
        [ResponseType(typeof(OfertaLaboralHabilidad))]
        public async Task<IHttpActionResult> DeleteOfertaLaboralHabilidad(int id)
        {
            OfertaLaboralHabilidad ofertaLaboralHabilidad = await db.OfertasLaboralesHabilidades.FindAsync(id);
            if (ofertaLaboralHabilidad == null)
            {
                return NotFound();
            }

            db.OfertasLaboralesHabilidades.Remove(ofertaLaboralHabilidad);
            await db.SaveChangesAsync();

            return Ok(ofertaLaboralHabilidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfertaLaboralHabilidadExists(int id)
        {
            return db.OfertasLaboralesHabilidades.Count(e => e.ID == id) > 0;
        }
    }
}