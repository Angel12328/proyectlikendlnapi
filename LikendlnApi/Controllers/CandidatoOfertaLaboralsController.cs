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
    public class CandidatoOfertaLaboralsController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/CandidatoOfertaLaborals
        public IQueryable<CandidatoOfertaLaboral> GetCandidatosOfertaLaborales()
        {
            return db.CandidatosOfertaLaborales;
        }

        // GET: api/CandidatoOfertaLaborals/5
        [ResponseType(typeof(CandidatoOfertaLaboral))]
        public async Task<IHttpActionResult> GetCandidatoOfertaLaboral(int id)
        {
            CandidatoOfertaLaboral candidatoOfertaLaboral = await db.CandidatosOfertaLaborales.FindAsync(id);
            if (candidatoOfertaLaboral == null)
            {
                return NotFound();
            }

            return Ok(candidatoOfertaLaboral);
        }

        // PUT: api/CandidatoOfertaLaborals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoOfertaLaboral(int id, CandidatoOfertaLaboral candidatoOfertaLaboral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoOfertaLaboral.ID)
            {
                return BadRequest();
            }

            db.Entry(candidatoOfertaLaboral).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoOfertaLaboralExists(id))
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

        // POST: api/CandidatoOfertaLaborals
        [ResponseType(typeof(CandidatoOfertaLaboral))]
        public async Task<IHttpActionResult> PostCandidatoOfertaLaboral(CandidatoOfertaLaboral candidatoOfertaLaboral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatosOfertaLaborales.Add(candidatoOfertaLaboral);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoOfertaLaboral.ID }, candidatoOfertaLaboral);
        }

        // DELETE: api/CandidatoOfertaLaborals/5
        [ResponseType(typeof(CandidatoOfertaLaboral))]
        public async Task<IHttpActionResult> DeleteCandidatoOfertaLaboral(int id)
        {
            CandidatoOfertaLaboral candidatoOfertaLaboral = await db.CandidatosOfertaLaborales.FindAsync(id);
            if (candidatoOfertaLaboral == null)
            {
                return NotFound();
            }

            db.CandidatosOfertaLaborales.Remove(candidatoOfertaLaboral);
            await db.SaveChangesAsync();

            return Ok(candidatoOfertaLaboral);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoOfertaLaboralExists(int id)
        {
            return db.CandidatosOfertaLaborales.Count(e => e.ID == id) > 0;
        }
    }
}