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
    public class MensajeEmpresarialController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        // GET: api/MensajeEmpresarial
        public IQueryable<MensajeEmpresarial> GetMensajeBases()
        {
            return db.MensajesEmpresariales;
        }

        // GET: api/MensajeEmpresarial/5
        [ResponseType(typeof(MensajeEmpresarial))]
        public async Task<IHttpActionResult> GetMensajeEmpresarial(int id)
        {
            MensajeEmpresarial mensajeEmpresarial = await db.MensajesEmpresariales.FindAsync(id);
            if (mensajeEmpresarial == null)
            {
                return NotFound();
            }

            return Ok(mensajeEmpresarial);
        }

        // PUT: api/MensajeEmpresarial/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMensajeEmpresarial(int id, MensajeEmpresarial mensajeEmpresarial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mensajeEmpresarial.Id)
            {
                return BadRequest();
            }

            db.Entry(mensajeEmpresarial).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensajeEmpresarialExists(id))
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

        // POST: api/MensajeEmpresarial
        [ResponseType(typeof(MensajeEmpresarial))]
        public async Task<IHttpActionResult> PostMensajeEmpresarial(MensajeEmpresarial mensajeEmpresarial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MensajeBases.Add(mensajeEmpresarial);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mensajeEmpresarial.Id }, mensajeEmpresarial);
        }

        // DELETE: api/MensajeEmpresarial/5
        [ResponseType(typeof(MensajeEmpresarial))]
        public async Task<IHttpActionResult> DeleteMensajeEmpresarial(int id)
        {
            MensajeEmpresarial mensajeEmpresarial = await db.MensajesEmpresariales.FindAsync(id);
            if (mensajeEmpresarial == null)
            {
                return NotFound();
            }

            db.MensajeBases.Remove(mensajeEmpresarial);
            await db.SaveChangesAsync();

            return Ok(mensajeEmpresarial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MensajeEmpresarialExists(int id)
        {
            return db.MensajeBases.Count(e => e.Id == id) > 0;
        }
    }
}