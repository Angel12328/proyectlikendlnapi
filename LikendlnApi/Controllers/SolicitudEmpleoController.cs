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
    public class SolicitudEmpleoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/SolicitudEmpleo
        public IQueryable<SolicitudEmpleo> GetSolicitudEmpleos()
        {
            return db.SolicitudEmpleos;
        }

        // GET: api/SolicitudEmpleo/5
        [ResponseType(typeof(SolicitudEmpleo))]
        public async Task<IHttpActionResult> GetSolicitudEmpleo(int id)
        {
            SolicitudEmpleo solicitudEmpleo = await db.SolicitudEmpleos.FindAsync(id);
            if (solicitudEmpleo == null)
            {
                return NotFound();
            }

            return Ok(solicitudEmpleo);
        }

        // PUT: api/SolicitudEmpleo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSolicitudEmpleo(int id, SolicitudEmpleo solicitudEmpleo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solicitudEmpleo.ID)
            {
                return BadRequest();
            }

            db.Entry(solicitudEmpleo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudEmpleoExists(id))
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

        // POST: api/SolicitudEmpleo
        [ResponseType(typeof(SolicitudEmpleo))]
        public async Task<IHttpActionResult> PostSolicitudEmpleo(SolicitudEmpleo solicitudEmpleo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SolicitudEmpleos.Add(solicitudEmpleo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = solicitudEmpleo.ID }, solicitudEmpleo);
        }

        // DELETE: api/SolicitudEmpleo/5
        [ResponseType(typeof(SolicitudEmpleo))]
        public async Task<IHttpActionResult> DeleteSolicitudEmpleo(int id)
        {
            SolicitudEmpleo solicitudEmpleo = await db.SolicitudEmpleos.FindAsync(id);
            if (solicitudEmpleo == null)
            {
                return NotFound();
            }

            db.SolicitudEmpleos.Remove(solicitudEmpleo);
            await db.SaveChangesAsync();

            return Ok(solicitudEmpleo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolicitudEmpleoExists(int id)
        {
            return db.SolicitudEmpleos.Count(e => e.ID == id) > 0;
        }
    }
}