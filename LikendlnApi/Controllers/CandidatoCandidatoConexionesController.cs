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
    public class CandidatoCandidatoConexionesController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/CandidatoCandidatoConexiones
        public IQueryable<CandidatoCandidatoConexiones> GetCandidatoCandidatoConexiones()
        {
            return db.CandidatoCandidatoConexiones;
        }

        // GET: api/CandidatoCandidatoConexiones/5
        [ResponseType(typeof(CandidatoCandidatoConexiones))]
        public async Task<IHttpActionResult> GetCandidatoCandidatoConexiones(int id)
        {
            CandidatoCandidatoConexiones candidatoCandidatoConexiones = await db.CandidatoCandidatoConexiones.FindAsync(id);
            if (candidatoCandidatoConexiones == null)
            {
                return NotFound();
            }

            return Ok(candidatoCandidatoConexiones);
        }

        // PUT: api/CandidatoCandidatoConexiones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoCandidatoConexiones(int id, CandidatoCandidatoConexiones candidatoCandidatoConexiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoCandidatoConexiones.ID)
            {
                return BadRequest();
            }

            db.Entry(candidatoCandidatoConexiones).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoCandidatoConexionesExists(id))
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

        // POST: api/CandidatoCandidatoConexiones
        [ResponseType(typeof(CandidatoCandidatoConexiones))]
        public async Task<IHttpActionResult> PostCandidatoCandidatoConexiones(CandidatoCandidatoConexiones candidatoCandidatoConexiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatoCandidatoConexiones.Add(candidatoCandidatoConexiones);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoCandidatoConexiones.ID }, candidatoCandidatoConexiones);
        }

        // DELETE: api/CandidatoCandidatoConexiones/5
        [ResponseType(typeof(CandidatoCandidatoConexiones))]
        public async Task<IHttpActionResult> DeleteCandidatoCandidatoConexiones(int id)
        {
            CandidatoCandidatoConexiones candidatoCandidatoConexiones = await db.CandidatoCandidatoConexiones.FindAsync(id);
            if (candidatoCandidatoConexiones == null)
            {
                return NotFound();
            }

            db.CandidatoCandidatoConexiones.Remove(candidatoCandidatoConexiones);
            await db.SaveChangesAsync();

            return Ok(candidatoCandidatoConexiones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoCandidatoConexionesExists(int id)
        {
            return db.CandidatoCandidatoConexiones.Count(e => e.ID == id) > 0;
        }
    }
}