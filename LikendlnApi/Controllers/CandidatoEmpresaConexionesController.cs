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
    public class CandidatoEmpresaConexionesController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/CandidatoEmpresaConexiones
        public IQueryable<CandidatoEmpresaConexiones> GetCandidatoEmpresaConexiones()
        {
            return db.CandidatoEmpresaConexiones;
        }

        // GET: api/CandidatoEmpresaConexiones/5
        [ResponseType(typeof(CandidatoEmpresaConexiones))]
        public async Task<IHttpActionResult> GetCandidatoEmpresaConexiones(int id)
        {
            CandidatoEmpresaConexiones candidatoEmpresaConexiones = await db.CandidatoEmpresaConexiones.FindAsync(id);
            if (candidatoEmpresaConexiones == null)
            {
                return NotFound();
            }

            return Ok(candidatoEmpresaConexiones);
        }

        // PUT: api/CandidatoEmpresaConexiones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoEmpresaConexiones(int id, CandidatoEmpresaConexiones candidatoEmpresaConexiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoEmpresaConexiones.Id)
            {
                return BadRequest();
            }

            db.Entry(candidatoEmpresaConexiones).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoEmpresaConexionesExists(id))
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

        // POST: api/CandidatoEmpresaConexiones
        [ResponseType(typeof(CandidatoEmpresaConexiones))]
        public async Task<IHttpActionResult> PostCandidatoEmpresaConexiones(CandidatoEmpresaConexiones candidatoEmpresaConexiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatoEmpresaConexiones.Add(candidatoEmpresaConexiones);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoEmpresaConexiones.Id }, candidatoEmpresaConexiones);
        }

        // DELETE: api/CandidatoEmpresaConexiones/5
        [ResponseType(typeof(CandidatoEmpresaConexiones))]
        public async Task<IHttpActionResult> DeleteCandidatoEmpresaConexiones(int id)
        {
            CandidatoEmpresaConexiones candidatoEmpresaConexiones = await db.CandidatoEmpresaConexiones.FindAsync(id);
            if (candidatoEmpresaConexiones == null)
            {
                return NotFound();
            }

            db.CandidatoEmpresaConexiones.Remove(candidatoEmpresaConexiones);
            await db.SaveChangesAsync();

            return Ok(candidatoEmpresaConexiones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoEmpresaConexionesExists(int id)
        {
            return db.CandidatoEmpresaConexiones.Count(e => e.Id == id) > 0;
        }
    }
}