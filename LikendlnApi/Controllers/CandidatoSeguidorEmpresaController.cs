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
    public class CandidatoSeguidorEmpresaController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/CandidatoSeguidorEmpresa
        public IQueryable<CandidatoSeguidorEmpresa> GetCandidatosSeguidoresEmpresas()
        {
            return db.CandidatosSeguidoresEmpresas;
        }

        // GET: api/CandidatoSeguidorEmpresa/5
        [ResponseType(typeof(CandidatoSeguidorEmpresa))]
        public async Task<IHttpActionResult> GetCandidatoSeguidorEmpresa(int id)
        {
            CandidatoSeguidorEmpresa candidatoSeguidorEmpresa = await db.CandidatosSeguidoresEmpresas.FindAsync(id);
            if (candidatoSeguidorEmpresa == null)
            {
                return NotFound();
            }

            return Ok(candidatoSeguidorEmpresa);
        }

        // PUT: api/CandidatoSeguidorEmpresa/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidatoSeguidorEmpresa(int id, CandidatoSeguidorEmpresa candidatoSeguidorEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoSeguidorEmpresa.Id)
            {
                return BadRequest();
            }

            db.Entry(candidatoSeguidorEmpresa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoSeguidorEmpresaExists(id))
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

        // POST: api/CandidatoSeguidorEmpresa
        [ResponseType(typeof(CandidatoSeguidorEmpresa))]
        public async Task<IHttpActionResult> PostCandidatoSeguidorEmpresa(CandidatoSeguidorEmpresa candidatoSeguidorEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CandidatosSeguidoresEmpresas.Add(candidatoSeguidorEmpresa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidatoSeguidorEmpresa.Id }, candidatoSeguidorEmpresa);
        }

        // DELETE: api/CandidatoSeguidorEmpresa/5
        [ResponseType(typeof(CandidatoSeguidorEmpresa))]
        public async Task<IHttpActionResult> DeleteCandidatoSeguidorEmpresa(int id)
        {
            CandidatoSeguidorEmpresa candidatoSeguidorEmpresa = await db.CandidatosSeguidoresEmpresas.FindAsync(id);
            if (candidatoSeguidorEmpresa == null)
            {
                return NotFound();
            }

            db.CandidatosSeguidoresEmpresas.Remove(candidatoSeguidorEmpresa);
            await db.SaveChangesAsync();

            return Ok(candidatoSeguidorEmpresa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatoSeguidorEmpresaExists(int id)
        {
            return db.CandidatosSeguidoresEmpresas.Count(e => e.Id == id) > 0;
        }
    }
}