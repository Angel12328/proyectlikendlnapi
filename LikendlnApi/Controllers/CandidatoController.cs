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
    public class CandidatoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/Candidato
        public IQueryable<Candidato> GetCandidatos()
        {
            return db.Candidatos;
        }

        // GET: api/Candidato/5
        [ResponseType(typeof(Candidato))]
        public async Task<IHttpActionResult> GetCandidato(int id)
        {
            Candidato candidato = await db.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            return Ok(candidato);
        }

        // PUT: api/Candidato/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidato(int id, Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidato.Id)
            {
                return BadRequest();
            }

            db.Entry(candidato).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
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

        // POST: api/Candidato
        [ResponseType(typeof(Candidato))]
        public async Task<IHttpActionResult> PostCandidato(Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Candidatos.Add(candidato);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidato.Id }, candidato);
        }

        // DELETE: api/Candidato/5
        [ResponseType(typeof(Candidato))]
        public async Task<IHttpActionResult> DeleteCandidato(int id)
        {
            Candidato candidato = await db.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            db.Candidatos.Remove(candidato);
            await db.SaveChangesAsync();

            return Ok(candidato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoExists(int id)
        {
            return db.Candidatos.Count(e => e.Id == id) > 0;
        }
    }
}