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
    public class ExperienciaLaboralController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/ExperienciaLaboral
        public IQueryable<ExperienciaLaboral> GetExperienciasLaborales()
        {
            return db.ExperienciasLaborales;
        }

        // GET: api/ExperienciaLaboral/5
        [ResponseType(typeof(ExperienciaLaboral))]
        public async Task<IHttpActionResult> GetExperienciaLaboral(int id)
        {
            ExperienciaLaboral experienciaLaboral = await db.ExperienciasLaborales.FindAsync(id);
            if (experienciaLaboral == null)
            {
                return NotFound();
            }

            return Ok(experienciaLaboral);
        }

        // PUT: api/ExperienciaLaboral/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExperienciaLaboral(int id, ExperienciaLaboral experienciaLaboral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != experienciaLaboral.ID)
            {
                return BadRequest();
            }

            db.Entry(experienciaLaboral).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienciaLaboralExists(id))
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

        // POST: api/ExperienciaLaboral
        [ResponseType(typeof(ExperienciaLaboral))]
        public async Task<IHttpActionResult> PostExperienciaLaboral(ExperienciaLaboral experienciaLaboral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExperienciasLaborales.Add(experienciaLaboral);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = experienciaLaboral.ID }, experienciaLaboral);
        }

        // DELETE: api/ExperienciaLaboral/5
        [ResponseType(typeof(ExperienciaLaboral))]
        public async Task<IHttpActionResult> DeleteExperienciaLaboral(int id)
        {
            ExperienciaLaboral experienciaLaboral = await db.ExperienciasLaborales.FindAsync(id);
            if (experienciaLaboral == null)
            {
                return NotFound();
            }

            db.ExperienciasLaborales.Remove(experienciaLaboral);
            await db.SaveChangesAsync();

            return Ok(experienciaLaboral);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExperienciaLaboralExists(int id)
        {
            return db.ExperienciasLaborales.Count(e => e.ID == id) > 0;
        }
    }
}