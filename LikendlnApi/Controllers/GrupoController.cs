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
    public class GrupoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/Grupo
        public IQueryable<Grupo> GetGrupos()
        {
            return db.Grupos;
        }

        // GET: api/Grupo/5
        [ResponseType(typeof(Grupo))]
        public async Task<IHttpActionResult> GetGrupo(int id)
        {
            Grupo grupo = await db.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }

            return Ok(grupo);
        }

        // PUT: api/Grupo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGrupo(int id, Grupo grupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupo.ID)
            {
                return BadRequest();
            }

            db.Entry(grupo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoExists(id))
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

        // POST: api/Grupo
        [ResponseType(typeof(Grupo))]
        public async Task<IHttpActionResult> PostGrupo(Grupo grupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grupos.Add(grupo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = grupo.ID }, grupo);
        }

        // DELETE: api/Grupo/5
        [ResponseType(typeof(Grupo))]
        public async Task<IHttpActionResult> DeleteGrupo(int id)
        {
            Grupo grupo = await db.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }

            db.Grupos.Remove(grupo);
            await db.SaveChangesAsync();

            return Ok(grupo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GrupoExists(int id)
        {
            return db.Grupos.Count(e => e.ID == id) > 0;
        }
    }
}