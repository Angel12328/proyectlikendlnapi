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
    public class MensajePrivadoController : ApiController
    {
        private readonly DbContextProyect db = new DbContextProyect();

        /// <summary>
        /// Obtiene todos los mensajes privados.
        /// </summary>
        /// <returns>Una lista de mensajes privados</returns>
        // GET: api/MensajePrivado
        public IQueryable<MensajePrivado> GetMensajeBases()
        {
            return db.MensajesPrivados;
        }

        /// <summary>
        /// Obtiene un mensaje privado específico.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // GET: api/MensajePrivado/5
        ///
        /// </remarks>
        /// <param name="id">El id del mensaje privado a obtener</param>
        /// <returns>Información del mensaje privado</returns>
        /// <response code="404">Si el mensaje privado no fue encontrado</response>
        /// <response code="200">Si el mensaje privado fue encontrado</response>
        // GET: api/MensajePrivado/5
        [ResponseType(typeof(MensajePrivado))]
        public async Task<IHttpActionResult> GetMensajePrivado(int id)
        {
            MensajePrivado mensajePrivado = await db.MensajesPrivados.FindAsync(id);
            if (mensajePrivado == null)
            {
                return NotFound();
            }

            return Ok(mensajePrivado);
        }

        /// <summary>
        /// Actualiza completamente un mensaje privado.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // PUT: api/MensajePrivado/5
        ///
        /// </remarks>
        /// <param name="id">El id del mensaje privado a actualizar</param>
        /// <param name="mensajePrivado">La información del mensaje privado a reemplazar</param>
        /// <returns>Vacío si el proceso es exitoso</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="400">Si el id no coincide con el mensaje privado</response>
        /// <response code="404">Si el mensaje privado no fue encontrado</response>
        /// <response code="204">Si el mensaje privado fue actualizado</response>
        // PUT: api/MensajePrivado/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMensajePrivado(int id, MensajePrivado mensajePrivado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mensajePrivado.Id)
            {
                return BadRequest();
            }

            db.Entry(mensajePrivado).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensajePrivadoExists(id))
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
        /// Crea un nuevo mensaje privado.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // POST: api/MensajePrivado
        ///
        /// </remarks>
        /// <param name="mensajePrivado">La información del mensaje privado a crear</param>
        /// <returns>El mensaje privado recién creado</returns>
        /// <response code="400">Si los datos ingresados no son válidos</response>
        /// <response code="201">Si el mensaje privado fue creado exitosamente</response>
        // POST: api/MensajePrivado
        [ResponseType(typeof(MensajePrivado))]
        public async Task<IHttpActionResult> PostMensajePrivado(MensajePrivado mensajePrivado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MensajesPrivados.Add(mensajePrivado);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mensajePrivado.Id }, mensajePrivado);
        }

        /// <summary>
        /// Elimina un mensaje privado específico.
        /// </summary>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     // DELETE: api/MensajePrivado/5
        ///
        /// </remarks>
        /// <param name="id">El id del mensaje privado a eliminar</param>
        /// <returns>El mensaje privado eliminado</returns>
        /// <response code="404">Si el mensaje privado no fue encontrado</response>
        /// <response code="200">Si el mensaje privado fue eliminado exitosamente</response>
        // DELETE: api/MensajePrivado/5
        [ResponseType(typeof(MensajePrivado))]
        public async Task<IHttpActionResult> DeleteMensajePrivado(int id)
        {
            MensajePrivado mensajePrivado = await db.MensajesPrivados.FindAsync(id);
            if (mensajePrivado == null)
            {
                return NotFound();
            }

            db.MensajesPrivados.Remove(mensajePrivado);
            await db.SaveChangesAsync();

            return Ok(mensajePrivado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MensajePrivadoExists(int id)
        {
            return db.MensajesPrivados.Count(e => e.Id == id) > 0;
        }
    }
}