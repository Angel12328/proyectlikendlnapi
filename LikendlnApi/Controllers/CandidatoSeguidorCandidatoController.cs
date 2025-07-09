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
    public class CandidatoSeguidorCandidatoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/CandidatoSeguidorCandidato
        public IQueryable<CandidatoSeguidorCandidato> GetCandidatoSeguidoresCandidatos()
        {
            return db.CandidatoSeguidoresCandidatos;
        }

        // GET: api/CandidatoSeguidorCandidato/5
        [ResponseType(typeof(CandidatoSeguidorCandidato))]
        public async Task<IHttpActionResult> GetCandidatoSeguidorCandidato(int id)
        {
            CandidatoSeguidorCandidato candidatoSeguidorCandidato = await db.CandidatoSeguidoresCandidatos.FindAsync(id);
            if (candidatoSeguidorCandidato == null)
            {
                return NotFound();
            }

            return Ok(candidatoSeguidorCandidato);
        }

        // PUT: api/CandidatoSeguidorCandidato/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoSeguidorCandidato(int id, CandidatoSeguidorCandidato candidatoSeguidorCandidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoSeguidorCandidato.Id)
            {
                return BadRequest();
            }

            db.Entry(candidatoSeguidorCandidato).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoSeguidorCandidatoExists(id))
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

        // POST: api/CandidatoSeguidorCandidato
        [ResponseType(typeof(CandidatoSeguidorCandidato))]
        public async Task<IHttpActionResult> PostCandidatoSeguidorCandidato(CandidatoSeguidorCandidato candidatoSeguidorCandidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatoSeguidoresCandidatos.Add(candidatoSeguidorCandidato);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoSeguidorCandidato.Id }, candidatoSeguidorCandidato);
        }

        // DELETE: api/CandidatoSeguidorCandidato/5
        [ResponseType(typeof(CandidatoSeguidorCandidato))]
        public async Task<IHttpActionResult> DeleteCandidatoSeguidorCandidato(int id)
        {
            CandidatoSeguidorCandidato candidatoSeguidorCandidato = await db.CandidatoSeguidoresCandidatos.FindAsync(id);
            if (candidatoSeguidorCandidato == null)
            {
                return NotFound();
            }

            db.CandidatoSeguidoresCandidatos.Remove(candidatoSeguidorCandidato);
            await db.SaveChangesAsync();

            return Ok(candidatoSeguidorCandidato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoSeguidorCandidatoExists(int id)
        {
            return db.CandidatoSeguidoresCandidatos.Count(e => e.Id == id) > 0;
        }
    }
}