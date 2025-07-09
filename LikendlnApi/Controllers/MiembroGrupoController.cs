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
    public class MiembroGrupoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/MiembroGrupo
        public IQueryable<MiembroGrupo> GetMiembrosGrupos()
        {
            return db.MiembrosGrupos;
        }

        // GET: api/MiembroGrupo/5
        [ResponseType(typeof(MiembroGrupo))]
        public async Task<IHttpActionResult> GetMiembroGrupo(int id)
        {
            MiembroGrupo miembroGrupo = await db.MiembrosGrupos.FindAsync(id);
            if (miembroGrupo == null)
            {
                return NotFound();
            }

            return Ok(miembroGrupo);
        }

        // PUT: api/MiembroGrupo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMiembroGrupo(int id, MiembroGrupo miembroGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != miembroGrupo.ID)
            {
                return BadRequest();
            }

            db.Entry(miembroGrupo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiembroGrupoExists(id))
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

        // POST: api/MiembroGrupo
        [ResponseType(typeof(MiembroGrupo))]
        public async Task<IHttpActionResult> PostMiembroGrupo(MiembroGrupo miembroGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MiembrosGrupos.Add(miembroGrupo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = miembroGrupo.ID }, miembroGrupo);
        }

        // DELETE: api/MiembroGrupo/5
        [ResponseType(typeof(MiembroGrupo))]
        public async Task<IHttpActionResult> DeleteMiembroGrupo(int id)
        {
            MiembroGrupo miembroGrupo = await db.MiembrosGrupos.FindAsync(id);
            if (miembroGrupo == null)
            {
                return NotFound();
            }

            db.MiembrosGrupos.Remove(miembroGrupo);
            await db.SaveChangesAsync();

            return Ok(miembroGrupo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MiembroGrupoExists(int id)
        {
            return db.MiembrosGrupos.Count(e => e.ID == id) > 0;
        }
    }
}