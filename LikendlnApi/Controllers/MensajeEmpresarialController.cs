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

        /// <summary>
        /// Obtiene todos los mensajes empresariales.
        /// </summary>
        /// <returns>Una lista de mensajes empresariales</returns>
        // GET: api/MensajeEmpresarial
        public IQueryable<MensajeEmpresarial> GetMensajesEmpresariales()
        {
            return db.MensajesEmpresariales;
        }

        /// <summary>
        /// Obtiene un mensaje empresarial específico.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // GET: api/MensajeEmpresarial/5
        ///
        /// </remarks>
        /// <param name="id">El id del mensaje empresarial a obtener</param>
        /// <returns>Información del mensaje empresarial</returns>
        /// <response code="404">Si el mensaje empresarial no fue encontrado</response>
        /// <response code="200">Si el mensaje empresarial fue encontrado</response>
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

        /// <summary>
        /// Actualiza completamente un mensaje empresarial.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/MensajeEmpresarial/5
        ///
        /// </remarks>
        /// <param name="id">El id del mensaje empresarial a actualizar</param>
        /// <param name="mensajeEmpresarial">La información del mensaje empresarial a reemplazar</param>
        /// <returns>Vacío si el proceso es exitoso</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="400">Si el id no coincide con el mensaje empresarial</response>
        /// <response code="404">Si el mensaje empresarial no fue encontrado</response>
        /// <response code="204">Si el mensaje empresarial fue actualizado</response>
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

        /// <summary>
        /// Crea un nuevo mensaje empresarial.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // POST: api/MensajeEmpresarial
        ///
        /// </remarks>
        /// <param name="mensajeEmpresarial">La información del mensaje empresarial a crear</param>
        /// <returns>El mensaje empresarial recién creado</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="201">Si el mensaje empresarial fue creado exitosamente</response>
        // POST: api/MensajeEmpresarial
        [ResponseType(typeof(MensajeEmpresarial))]
        public async Task<IHttpActionResult> PostMensajeEmpresarial(MensajeEmpresarial mensajeEmpresarial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MensajesEmpresariales.Add(mensajeEmpresarial);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mensajeEmpresarial.Id }, mensajeEmpresarial);
        }

        /// <summary>
        /// Elimina un mensaje empresarial específico.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // DELETE: api/MensajeEmpresarial/5
        ///
        /// </remarks>
        /// <param name="id">El id del mensaje empresarial a eliminar</param>
        /// <returns>El mensaje empresarial eliminado</returns>
        /// <response code="404">Si el mensaje empresarial no fue encontrado</response>
        /// <response code="200">Si el mensaje empresarial fue eliminado exitosamente</response>
        // DELETE: api/MensajeEmpresarial/5
        [ResponseType(typeof(MensajeEmpresarial))]
        public async Task<IHttpActionResult> DeleteMensajeEmpresarial(int id)
        {
            MensajeEmpresarial mensajeEmpresarial = await db.MensajesEmpresariales.FindAsync(id);
            if (mensajeEmpresarial == null)
            {
                return NotFound();
            }

            db.MensajesEmpresariales.Remove(mensajeEmpresarial);
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
            return db.MensajesEmpresariales.Count(e => e.Id == id) > 0;
        }
    }
}