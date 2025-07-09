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
    public class CandidatoGrupoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/CandidatoGrupo
        public IQueryable<CandidatoGrupo> GetCandidatosGrupos()
        {
            return db.CandidatosGrupos;
        }

        // GET: api/CandidatoGrupo/5
        [ResponseType(typeof(CandidatoGrupo))]
        public async Task<IHttpActionResult> GetCandidatoGrupo(int id)
        {
            CandidatoGrupo candidatoGrupo = await db.CandidatosGrupos.FindAsync(id);
            if (candidatoGrupo == null)
            {
                return NotFound();
            }

            return Ok(candidatoGrupo);
        }

        // PUT: api/CandidatoGrupo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoGrupo(int id, CandidatoGrupo candidatoGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoGrupo.ID)
            {
                return BadRequest();
            }

            db.Entry(candidatoGrupo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoGrupoExists(id))
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

        // POST: api/CandidatoGrupo
        [ResponseType(typeof(CandidatoGrupo))]
        public async Task<IHttpActionResult> PostCandidatoGrupo(CandidatoGrupo candidatoGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatosGrupos.Add(candidatoGrupo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoGrupo.ID }, candidatoGrupo);
        }

        // DELETE: api/CandidatoGrupo/5
        [ResponseType(typeof(CandidatoGrupo))]
        public async Task<IHttpActionResult> DeleteCandidatoGrupo(int id)
        {
            CandidatoGrupo candidatoGrupo = await db.CandidatosGrupos.FindAsync(id);
            if (candidatoGrupo == null)
            {
                return NotFound();
            }

            db.CandidatosGrupos.Remove(candidatoGrupo);
            await db.SaveChangesAsync();

            return Ok(candidatoGrupo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoGrupoExists(int id)
        {
            return db.CandidatosGrupos.Count(e => e.ID == id) > 0;
        }
    }
}