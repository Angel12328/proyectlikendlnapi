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
    public class EmpresaSeguidorEmpresaController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();
        /// <summary>
        /// Obtiene todos las empresas seguidores de otras empresas.
        /// </summary>
        /// <returns>Una lista de empresas seguidores de empresas.</returns>
        // GET: api/EmpresaSeguidorEmpresa
        public IQueryable<EmpresaSeguidorEmpresa> GetEmpresaSeguidoresEmpresas()
        {
            return db.EmpresaSeguidoresEmpresas;
        }

        // GET: api/EmpresaSeguidorEmpresa/5
        [ResponseType(typeof(EmpresaSeguidorEmpresa))]
        public async Task<IHttpActionResult> GetEmpresaSeguidorEmpresa(int id)
        {
            EmpresaSeguidorEmpresa empresaSeguidorEmpresa = await db.EmpresaSeguidoresEmpresas.FindAsync(id);
            if (empresaSeguidorEmpresa == null)
            {
                return NotFound();
            }

            return Ok(empresaSeguidorEmpresa);
        }

        // PUT: api/EmpresaSeguidorEmpresa/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpresaSeguidorEmpresa(int id, EmpresaSeguidorEmpresa empresaSeguidorEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empresaSeguidorEmpresa.Id)
            {
                return BadRequest();
            }

            db.Entry(empresaSeguidorEmpresa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaSeguidorEmpresaExists(id))
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

        // POST: api/EmpresaSeguidorEmpresa
        [ResponseType(typeof(EmpresaSeguidorEmpresa))]
        public async Task<IHttpActionResult> PostEmpresaSeguidorEmpresa(EmpresaSeguidorEmpresa empresaSeguidorEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpresaSeguidoresEmpresas.Add(empresaSeguidorEmpresa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = empresaSeguidorEmpresa.Id }, empresaSeguidorEmpresa);
        }

        // DELETE: api/EmpresaSeguidorEmpresa/5
        [ResponseType(typeof(EmpresaSeguidorEmpresa))]
        public async Task<IHttpActionResult> DeleteEmpresaSeguidorEmpresa(int id)
        {
            EmpresaSeguidorEmpresa empresaSeguidorEmpresa = await db.EmpresaSeguidoresEmpresas.FindAsync(id);
            if (empresaSeguidorEmpresa == null)
            {
                return NotFound();
            }

            db.EmpresaSeguidoresEmpresas.Remove(empresaSeguidorEmpresa);
            await db.SaveChangesAsync();

            return Ok(empresaSeguidorEmpresa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpresaSeguidorEmpresaExists(int id)
        {
            return db.EmpresaSeguidoresEmpresas.Count(e => e.Id == id) > 0;
        }
    }
}