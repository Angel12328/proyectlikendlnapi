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
    public class EmpresaSeguidorCandidatoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/EmpresaSeguidorCandidato
        public IQueryable<EmpresaSeguidorCandidato> GetEmpresaSeguidoresCandidatos()
        {
            return db.EmpresaSeguidoresCandidatos;
        }

        // GET: api/EmpresaSeguidorCandidato/5
        [ResponseType(typeof(EmpresaSeguidorCandidato))]
        public async Task<IHttpActionResult> GetEmpresaSeguidorCandidato(int id)
        {
            EmpresaSeguidorCandidato empresaSeguidorCandidato = await db.EmpresaSeguidoresCandidatos.FindAsync(id);
            if (empresaSeguidorCandidato == null)
            {
                return NotFound();
            }

            return Ok(empresaSeguidorCandidato);
        }

        // PUT: api/EmpresaSeguidorCandidato/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpresaSeguidorCandidato(int id, EmpresaSeguidorCandidato empresaSeguidorCandidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empresaSeguidorCandidato.Id)
            {
                return BadRequest();
            }

            db.Entry(empresaSeguidorCandidato).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaSeguidorCandidatoExists(id))
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

        // POST: api/EmpresaSeguidorCandidato
        [ResponseType(typeof(EmpresaSeguidorCandidato))]
        public async Task<IHttpActionResult> PostEmpresaSeguidorCandidato(EmpresaSeguidorCandidato empresaSeguidorCandidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpresaSeguidoresCandidatos.Add(empresaSeguidorCandidato);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = empresaSeguidorCandidato.Id }, empresaSeguidorCandidato);
        }

        // DELETE: api/EmpresaSeguidorCandidato/5
        [ResponseType(typeof(EmpresaSeguidorCandidato))]
        public async Task<IHttpActionResult> DeleteEmpresaSeguidorCandidato(int id)
        {
            EmpresaSeguidorCandidato empresaSeguidorCandidato = await db.EmpresaSeguidoresCandidatos.FindAsync(id);
            if (empresaSeguidorCandidato == null)
            {
                return NotFound();
            }

            db.EmpresaSeguidoresCandidatos.Remove(empresaSeguidorCandidato);
            await db.SaveChangesAsync();

            return Ok(empresaSeguidorCandidato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpresaSeguidorCandidatoExists(int id)
        {
            return db.EmpresaSeguidoresCandidatos.Count(e => e.Id == id) > 0;
        }
    }
}