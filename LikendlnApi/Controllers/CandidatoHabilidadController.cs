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
    public class CandidatoHabilidadController : ApiController
    {
        private  readonly DbContextProyect db = new DbContextProyect();

        // GET: api/CandidatoHabilidad
        public IQueryable<CandidatoHabilidad> GetCandidatosHabilidades()
        {
            return db.CandidatosHabilidades;
        }

        // GET: api/CandidatoHabilidad/5
        [ResponseType(typeof(CandidatoHabilidad))]
        public async Task<IHttpActionResult> GetCandidatoHabilidad(int id)
        {
            CandidatoHabilidad candidatoHabilidad = await db.CandidatosHabilidades.FindAsync(id);
            if (candidatoHabilidad == null)
            {
                return NotFound();
            }

            return Ok(candidatoHabilidad);
        }

        // PUT: api/CandidatoHabilidad/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoHabilidad(int id, CandidatoHabilidad candidatoHabilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoHabilidad.ID)
            {
                return BadRequest();
            }

            db.Entry(candidatoHabilidad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoHabilidadExists(id))
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

        // POST: api/CandidatoHabilidad
        [ResponseType(typeof(CandidatoHabilidad))]
        public async Task<IHttpActionResult> PostCandidatoHabilidad(CandidatoHabilidad candidatoHabilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatosHabilidades.Add(candidatoHabilidad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoHabilidad.ID }, candidatoHabilidad);
        }

        // DELETE: api/CandidatoHabilidad/5
        [ResponseType(typeof(CandidatoHabilidad))]
        public async Task<IHttpActionResult> DeleteCandidatoHabilidad(int id)
        {
            CandidatoHabilidad candidatoHabilidad = await db.CandidatosHabilidades.FindAsync(id);
            if (candidatoHabilidad == null)
            {
                return NotFound();
            }

            db.CandidatosHabilidades.Remove(candidatoHabilidad);
            await db.SaveChangesAsync();

            return Ok(candidatoHabilidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoHabilidadExists(int id)
        {
            return db.CandidatosHabilidades.Count(e => e.ID == id) > 0;
        }
    }
}